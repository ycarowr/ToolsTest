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
        private IGameFinished Handler { get; }

        public FinishGame(IPrimitiveGame game, IGameFinished handler) : base(game)
        {
            Handler = handler;
        }

        public override void Execute()
        {
            if (!Game.IsGameStarted)
                return;
            if (Game.IsGameFinished)
                return;

            Game.IsGameFinished = true;
            Handler.OnGameFinished(Game.Token.CurrentPlayer);
        }
    }
}