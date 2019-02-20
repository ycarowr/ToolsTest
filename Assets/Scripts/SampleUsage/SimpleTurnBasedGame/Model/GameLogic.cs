using System.Collections.Generic;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     Simple concrete GameLogic Implementation.
    /// </summary>
    public class GameLogic : IPrimitiveGameLogic
    {
        public GameLogic(List<IPrimitivePlayer> players, IGameLogicActions handler)
        {
            Handler = handler;
            Token = new TokenCurrentPlayer(players);
            Log("GameLogic Created");
        }

        public TokenCurrentPlayer Token { get; }
        ITokenCurrentPlayer IPrimitiveGameLogic.Token => Token;
        private IGameLogicActions Handler { get; }
        public bool IsGameStarted { get; private set; }
        public bool IsGameFinished { get; private set; }
        public bool IsTurnInProgress { get; private set; }

        void IPrimitiveGameLogic.StartGame()
        {
            if (IsGameStarted) return;

            IsGameStarted = true;
            Log("Game Started");
            Handler.OnGameStarted(Token.StarterPlayer);
        }

        void IPrimitiveGameLogic.FinishGame()
        {
            if (!IsGameStarted) return;
            if (IsGameFinished) return;

            IsGameFinished = true;
            Log("Game Finished");
            Handler.OnGameFinished(Token.CurrentPlayer);
        }

        void IPrimitiveGameLogic.StartCurrentPlayerTurn()
        {
            if (IsTurnInProgress) return;
            if (!IsGameStarted) return;
            if (IsGameFinished) return;

            IsTurnInProgress = true;
            Token.UpdateCurrentPlayerIndex();
            Token.CurrentPlayer.StartTurn();
            Log("Started Current Player Turn");
            Handler.OnStartedCurrentPlayerTurn(Token.CurrentPlayer);
        }

        void IPrimitiveGameLogic.FinishCurrentPlayerTurn()
        {
            if (IsTurnInProgress) return;
            if (!IsGameStarted) return;
            if (IsGameFinished) return;

            IsTurnInProgress = false;
            Token.CurrentPlayer.FinishTurn();
            Handler.OnFinishedCurrentPlayerTurn(Token.CurrentPlayer);
            Log("Pass Turn");
        }

        private void Log(string log, string colorName = "black")
        {
            log = string.Format("[" + GetType() + "]: <color={0}><b>" + log + "</b></color>", colorName);
            Debug.Log(log);
        }
    }
}