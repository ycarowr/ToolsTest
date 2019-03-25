using System;
using System.Collections;
using Patterns;
using SimpleTurnBasedGame.ControllerCs;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     This class initializes all components and kicks the start game.
    /// </summary>
    public class Bootstrapper : SingletonMB<Bootstrapper>
    {
        #region Fields
        
        [Header("Configurations")] [SerializeField]
        private Configurations configurations;
            
        [Header("Prefabs")]
        [SerializeField] private GameObject UIPrefab;
        [SerializeField] private GameData GameDataPrefab;
        [SerializeField] private GameEvents GameEventsPrefab;
        [SerializeField] private GameController GameControllerPrefab;

        #endregion

        #region Properties

        private GameObject Ui { get; set; }
        private GameData GameData { get; set; }
        private GameEvents GameEvents { get; set; }
        private GameController GameController { get; set; }
        private Configurations Configurations => configurations;
        public bool IsInitialized { get; private set; }
        public bool IsStarted { get; private set; }

        #endregion

        #region Unity Callbacks

        /// <summary>
        ///     Main. First Awake that happens in the entire game.
        /// </summary>
        protected override void OnAwake()
        {
            Logger.Instance.Log<Bootstrapper>("Awake");
            InitializeGame();
        }
        
        /// <summary>
        ///     First Start in the game.
        /// </summary>
        private void Start()
        {
            Logger.Instance.Log<Bootstrapper>("Start");
            StartGame();
        }

        #endregion

        /// <summary>
        ///     Boots all the game instantiating the necessary prefabs in the correct order.
        /// </summary>
        private void InitializeGame()
        {
            if (IsInitialized)
                return;

            //Create game events Singleton
            GameEvents = Instantiate(GameEventsPrefab);

            //Create game ui
            Ui = Instantiate(UIPrefab);

            //Create game data Singleton
            GameData = Instantiate(GameDataPrefab);

            //Create game controller Singleton
            GameController = Instantiate(GameControllerPrefab);

            IsInitialized = true;
        }

        /// <summary>
        ///     Kicks the start game state after booting the game.
        /// </summary>s
        private void StartGame()
        {
            if (!IsInitialized)
                return;

            if (IsStarted)
                return;

            GameController.StartBattle();
            IsStarted = true;
        }
    }
}
