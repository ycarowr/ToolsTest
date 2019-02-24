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

        private void Start()
        {
            //create and connect players to their seats
            var player1 = new Player(PlayerSeat.Bottom);
            var player2 = new Player(PlayerSeat.Top);

            //create game logic
            RuntimeGame = new Game(new List<IPrimitivePlayer> { player1, player2 });
            
            //Initialize State Machine this game the data
            TurnBasedController.Instance.Initialize(RuntimeGame);

            //Push the start battle state
            TurnBasedController.Instance.StartBattle();
        }
    }
}