﻿using Patterns;
using UnityEngine;

namespace SimpleTurnBasedGame.ControllerCs
{
    /// <summary>
    ///     Main Controller. Holds the FSM which controls the game flow. Also provides access to the players controllers.
    /// </summary>
    public class GameController : SingletonMB<GameController>, IGameController
    {
        [SerializeField] private Configurations configurations;

        //----------------------------------------------------------------------------------------------------------

        #region Properties

        /// <summary>
        ///     All game data. Access via Singleton Pattern.
        /// </summary>
        public IGameData Data => GameData.Instance;

        /// <summary>
        ///     State machine that holds the game logic.
        /// </summary>
        private TurnBasedFSM TurnBasedLogic { get; set; }

        /// <summary>
        ///     Handler for the state machine. Used to dispatch coroutines.
        /// </summary>
        public MonoBehaviour MonoBehaviour => this;

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Initialization

        protected override void OnAwake()
        {
            Logger.Instance.Log<GameController>("Awake");
            TurnBasedLogic = new TurnBasedFSM(this, Data, configurations);
        }

        private void Start()
        {
            Logger.Instance.Log<GameController>("Start");
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Operations

        /// <summary>
        ///     Provides access to players controllers according to the player seat.
        /// </summary>
        /// <param name="seat"></param>
        /// <returns></returns>
        public IPlayerTurn GetPlayerController(PlayerSeat seat)
        {
            return TurnBasedLogic.GetPlayer(seat);
        }

        /// <summary>
        ///     Start Battle. Called by the bootstrapper only during the first launch of the game.
        /// </summary>
        [Button]
        public void StartBattle()
        {
            TurnBasedLogic.StartBattle();
        }

        [Button]
        public void EndBattle()
        {
            TurnBasedLogic.EndBattle();
        }

        [Button]
        public void RestartGameImmediately()
        {
            TurnBasedLogic.RestartGameImmediately();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}