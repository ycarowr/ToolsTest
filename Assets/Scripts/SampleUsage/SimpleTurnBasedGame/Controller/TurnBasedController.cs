using System.Collections.Generic;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     This class is responsible to hold the game states which
    ///     control the game flow through a state machine where the states
    ///     act as controllers for each respective player.
    /// </summary>
    public class TurnBasedController : StateMachineMB<TurnBasedController>, IPlayerRegister
    {
        //Register with all States of the Players that are in the Match. Each state controls
        //the flow of the game 
        private readonly Dictionary<IPrimitivePlayer, TurnState> actorsRegister = new Dictionary<IPrimitivePlayer, TurnState>();

        //It holds the flow of the Player state
        private UserTurnState UserState { get; set; }

        //It holds the flow of the start game state
        private StartBattleState StartState { get; set; }

        //It holds the flow of the end game state
        private EndBattleState EndState { get; set; }


        public void Initialize(IPrimitiveGame game)
        {
            base.Initialize();
            
            StartState.RegisterRuntimeGame(game);
            EndState.RegisterRuntimeGame(game);
            foreach (var turnState in actorsRegister.Values)
                turnState.RegisterRuntimeGame(game);
        }

        protected override void OnBeforeInitialize()
        {
            //create StartGame and EndGame states
            StartState = gameObject.AddComponent<StartBattleState>();
            EndState = gameObject.AddComponent<EndBattleState>();
        }

        /// <summary>
        ///     Registers a player to its respective turn state.
        /// </summary>
        /// <param name="player"></param>
        public void RegisterPlayer(IPrimitivePlayer player)
        {
            if (UserState == null)
            {
                UserState = gameObject.AddComponent<UserTurnState>();
                UserState.RegisterPlayer(player);
                actorsRegister.Add(player, UserState);
            }
            else
            {
                var aiTurnState = gameObject.AddComponent<AITurnState>();
                aiTurnState.RegisterPlayer(player);
                actorsRegister.Add(player, aiTurnState);
            }
        }


        public TurnState GetPlayerTurn(IPrimitivePlayer player)
        {
            return IsInitialized && actorsRegister.ContainsKey(player) ? actorsRegister[player] : null;
        }

        /// <summary>
        ///     Call this method to Push Start Battle State and begin the match.
        /// </summary>
        public void StartBattle()
        {
            if (!IsInitialized)
                return;

            PopState();
            PushState(StartState);
        }

        /// <summary>
        ///     Call this method to Push End Battle State and Finish the match.
        /// </summary>
        public void EndBattle()
        {
            if (!IsInitialized)
                return;

            PopState();
            PushState(EndState);
        }
    }
}