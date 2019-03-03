using System.Collections;
using System.Collections.Generic;
using Patterns;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class GameData : SingletonMB<GameData>
    {
        /// <summary>
        ///     All the game logic implementation and game data.
        /// </summary>
        public IPrimitiveGame RuntimeGame { get; private set; }

        /// <summary>
        /// Initialize game data OnAwake.
        /// </summary>
        protected override void OnAwake()
        {
            CreateGameState();
        }

        public void CreateGameState()
        {
            //create and connect players to their seats
            var player1 = new Player(PlayerSeat.Bottom);
            var player2 = new Player(PlayerSeat.Top);

            //create game logic
            RuntimeGame = new Game(new List<IPrimitivePlayer> { player1, player2 });
        }
    }
}