using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     This class is responsible to hold the game states which
    ///     control the game flow through a state machine where the states
    ///     act as controllers for each respective player.
    /// </summary>
    public class TurnBasedController : StateMachineMB<TurnBasedController>
    {
        //Register with all States of the Players that are in the Match. Each state controls
        //the flow of the game 
        private readonly Dictionary<IPrimitivePlayer, TurnState> actorsRegister = new Dictionary<IPrimitivePlayer, TurnState>();

        //It holds the flow of the Player state
        public UserTurnState UserState { get; set; }

        //It holds the flow of the start game state
        private StartBattleState StartState { get; set; }

        //It holds the flow of the end game state
        private EndBattleState EndState { get; set; }

        public void Initialize(IPrimitiveGame game)
        {
            base.Initialize();

            //user is always the bottom player
            var user = game.Token.GetPlayer(PlayerSeat.Bottom);
            var opponent = game.Token.GetOpponent(user);
            
            //register both players
            RegisterPlayer(user, game);
            RegisterPlayer(opponent, game);

            //register the game
            StartState.InjectDependency(game);
            EndState.InjectDependency(game);
        }

        protected override void OnBeforeInitialize()
        {
            //create StartTheGame and EndGame states
            StartState = GetComponent<StartBattleState>();
            EndState = GetComponent<EndBattleState>();
        }

        /// <summary>
        ///     Registers a player to its respective turn state.
        /// </summary>
        /// <param name="player"></param>
        private void RegisterPlayer(IPrimitivePlayer player, IPrimitiveGame game)
        {
            if (UserState == null)
            {
                UserState = GetComponent<UserTurnState>();
                UserState.InjectDependencies(player, game);
                actorsRegister.Add(player, UserState);
            }
            else
            {
                var aiTurnState = GetComponent<AiTurnState>();
                aiTurnState.InjectDependencies(player, game);
                actorsRegister.Add(player, aiTurnState);
            }
        }

        /// <summary>
        /// Returns whether the current player is sitting on a specified seat.
        /// </summary>
        /// <param name="seat"></param>
        /// <returns></returns>
        public bool IsCurrentPlayerOnSeat(PlayerSeat seat)
        {
            if (!IsInitialized)
                return false;

            var currentState = PeekState();
            return currentState != null && GetPlayer(seat).IsMyTurn();
        }

        /// <summary>
        /// Check if the player is the Player User.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public bool IsUser(IPrimitivePlayer player)
        {
            return UserState.Player == player;
        }

        /// <summary>
        /// Returns a Turn according to its registered player.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public TurnState GetPlayer(IPrimitivePlayer player)
        {
            return IsInitialized && actorsRegister.ContainsKey(player) ? actorsRegister[player] : null;
        }

        /// <summary>
        /// Returns a the player turn according to the position. Null if there isn't player registered with the argument.
        /// </summary>
        /// <param name="seat"></param>
        /// <returns></returns>
        public TurnState GetPlayer(PlayerSeat seat)
        {
            foreach (var player in actorsRegister.Keys)
            {
                if (player.Seat == seat)
                    return actorsRegister[player];
            }

            return null;
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

        public override void Restart()
        {
            base.Restart();

            //clear user state
            UserState = null;

            //reset states
            foreach (var turnState in actorsRegister.Values)
                turnState.Restart();

            //clear turn state register
            actorsRegister.Clear();
        }
    }
}