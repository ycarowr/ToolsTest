using System.Collections;
using System.Collections.Generic;
using Patterns;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public interface IGameData
    {
        IPrimitiveGame RuntimeGame { get; }
        void Clear();
        void CreateGame();
    }

    [RequireComponent(typeof(GameController))]
    public class GameData : MonoBehaviour, IGameData
    {
        /// <summary>
        ///     All the game logic implementation and game data.
        /// </summary>
        public IPrimitiveGame RuntimeGame { get; private set; }

        /// <summary>
        /// Initialize game data OnAwake.
        /// </summary>
        private void Awake()
        {
            CreateGame();
        }

        public void Clear()
        {
            RuntimeGame = null;
        }

        public void CreateGame()
        {
            //create and connect players to their seats
            var player1 = new Player(PlayerSeat.Bottom);
            var player2 = new Player(PlayerSeat.Top);

            //create game logic
            RuntimeGame = new Game(new List<IPrimitivePlayer> { player1, player2 });
        }
    }
}