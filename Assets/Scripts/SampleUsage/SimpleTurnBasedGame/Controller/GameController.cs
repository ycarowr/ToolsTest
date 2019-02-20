using System.Collections.Generic;
using Patterns;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     This class is responsible to Setup and Initialize the game structures. It holds the
    ///     game states which control the game flow also the implementation of the GameLogic.
    /// </summary>
    public class GameController : StateMachineMB<GameController>, IGameLogicActions
    {
        //Register with all States of the Players that are in the Match. Each state controls
        //the flow of the game 
        private readonly List<TurnState> turnStates = new List<TurnState>();

        [Tooltip("Whether the second player is AI or not")] [SerializeField]
        private bool isAiEnabled;

        //It holds the flow of the start game state
        private StartBattleState StartState { get; set; }

        //It holds the flow of the end game state
        private EndBattleState EndState { get; set; }

        //All the game logic implementation
        private IPrimitiveGameLogic GameLogic { get; set; }

        void IGameLogicActions.OnGameStarted(IPrimitivePlayer starter)
        {
        }

        void IGameLogicActions.OnGameFinished(IPrimitivePlayer winner)
        {
        }

        void IGameLogicActions.OnStartedCurrentPlayerTurn(IPrimitivePlayer player)
        {
        }

        void IGameLogicActions.OnFinishedCurrentPlayerTurn(IPrimitivePlayer player)
        {
        }

        //Before the State Machine Initialize
        protected override void OnBeforeInitialize()
        {
            //create StartGame and EndGame states
            StartState = gameObject.AddComponent<StartBattleState>();
            EndState = gameObject.AddComponent<EndBattleState>();

            //create User state
            var userState = gameObject.AddComponent<UserTurnState>();
            turnStates.Add(userState);

            //choose Ai or Player2 to play as second player
            var type = isAiEnabled ? typeof(AITurnState) : typeof(Player2TurnState);
            var player2State = (TurnState) gameObject.AddComponent(type);
            turnStates.Add(player2State);

            //create player seats
            var userSeat = PlayerSeat.Bottom;
            var secondSeat = PlayerSeat.Top;

            //create and connect players to their seats
            var userPlayer = new Player(userSeat);
            var player2 = new Player(secondSeat);

            //create game logic
            GameLogic = new GameLogic(new List<IPrimitivePlayer> {userPlayer, player2}, this);

            //register players in their respective states
            userState.RegisterPlayer(userPlayer);
            player2State.RegisterPlayer(player2);

            //inject game logic into states
            StartState.InjectGameLogic(GameLogic);
            EndState.InjectGameLogic(GameLogic);
            userState.InjectGameLogic(GameLogic);
            player2State.InjectGameLogic(GameLogic);

            //register states to their respective player UIs
            PlayersController.Instance.RegisterPlayer(userState);
            PlayersController.Instance.RegisterPlayer(player2State);
        }

        protected override void Start()
        {
            base.Start();
            StartBattle();
        }

        /// <summary>
        ///     Call this method to Push Start Battle State and begin the match.
        /// </summary>
        private void StartBattle()
        {
            if (!IsInitialized)
                return;

            PopState();
            PushState(StartState);
        }

        /// <summary>
        ///     Call this method to Push End Battle State and Finish the match.
        /// </summary>
        private void EndBattle()
        {
            if (!IsInitialized)
                return;

            PopState();
            PushState(EndState);
        }

        /// <summary>
        ///     Call this to pass the turn to the next player.
        /// </summary>
        private void PassTurn(IPrimitivePlayer nextPlayer)
        {
            if (!IsInitialized)
                return;

            //finds next player state
            var nextPlayerState = GetTurnState(nextPlayer);
            //remove current state
            PopState();
            //push state of the next player
            PushState(nextPlayerState);
        }

        /// <summary>
        ///     Returns the Turn State according to the Player's owner.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        private TurnState GetTurnState(IPrimitivePlayer player)
        {
            if (!IsInitialized)
                return null;

            foreach (var turnState in turnStates)
                if (turnState.Player == player)
                    return turnState;

            return null;
        }

        private void OnNextTurn(IPrimitivePlayer next)
        {
            PassTurn(next);
        }
    }
}