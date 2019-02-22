using System.Collections.Generic;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    /// <inheritdoc />
    /// <summary>
    ///     Finish Current Player Turn Implementation.
    /// </summary>
    public class FinishPlayerTurn : TurnStep
    {
        private IFinishedPlayerTurn Handler { get; }

        public FinishPlayerTurn(IPrimitiveGame game, IFinishedPlayerTurn handler) : base(game)
        {
            Handler = handler;
        }

        public override void Execute()
        {
            if (!Game.IsTurnInProgress) return;
            if (!Game.IsGameStarted) return;
            if (Game.IsGameFinished) return;

            Game.IsTurnInProgress = false;
            Game.Token.CurrentPlayer.FinishTurn();
            Handler.OnFinishedCurrentPlayerTurn(Game.Token.CurrentPlayer);
        }
    }
}