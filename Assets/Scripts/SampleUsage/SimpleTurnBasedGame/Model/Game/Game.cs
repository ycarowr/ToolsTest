using System.Collections.Generic;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     Simple concrete Game Implementation.
    /// </summary>
    public partial class Game : IPrimitiveGame
    {
        public Game(List<IPrimitivePlayer> players)
        {
            Token = new TokenCurrentPlayer(players);
            Log("Game Created");
        }

        public TokenCurrentPlayer Token { get; }
        ITokenCurrentPlayer IPrimitiveGame.Token => Token;
        public bool IsGameStarted { get; set; }
        public bool IsGameFinished { get; set; }
        public bool IsTurnInProgress { get; set; }

        private void Log(string log, string colorName = "black")
        {
            log = string.Format("[" + GetType() + "]: <color={0}><b>" + log + "</b></color>", colorName);
            Debug.Log(log);
        }
    }
}