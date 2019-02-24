using System;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    /// <inheritdoc />
    /// <summary>
    ///     Finish Game Step Implementation.
    /// </summary>
    public class FinishGame : TurnStep
    {
        public FinishGame(IPrimitiveGame game) : base(game)
        {

        }

        public void Execute()
        {
            if (!Game.IsGameStarted)
                return;
            if (Game.IsGameFinished)
                return;

            Game.IsGameFinished = true;

            OnGameFinished(Game.Token.CurrentPlayer);
        }

        private void OnGameFinished(IPrimitivePlayer currentPlayer)
        {
            
        }
    }
}