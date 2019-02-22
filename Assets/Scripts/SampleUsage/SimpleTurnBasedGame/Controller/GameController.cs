using System.Collections;
using System.Collections.Generic;
using Patterns;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class GameController : SingletonMB<GameController>
    {
        [Tooltip("Whether the second player is AI or not")] [SerializeField]
        private bool isAiEnabled = true;

        /// <summary>
        ///     All the game logic implementation and game data.
        /// </summary>
        private IPrimitiveGame RuntimeGame { get; set; }

        protected override void OnAwake()
        {
            //create player seats
            var userSeat = PlayerSeat.Bottom;
            var secondSeat = PlayerSeat.Top;

            //create and connect players to their seats
            var userPlayer = new Player(userSeat);
            var player2 = new Player(secondSeat);

            //create game logic
            RuntimeGame = new Game(new List<IPrimitivePlayer> { userPlayer, player2 });

            //assign players to their state controllers
            TurnBasedController.Instance.RegisterPlayer(userPlayer);
            TurnBasedController.Instance.RegisterPlayer(player2);

            //Initialize State Machine this game the data
            TurnBasedController.Instance.Initialize(RuntimeGame);
        }

        private void Start()
        {
            TurnBasedController.Instance.StartBattle();
        }
    }
}