using System.Collections.Generic;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    /// <inheritdoc />
    /// <summary>
    ///     Start Game Step Implementation.
    /// </summary>
    public class StartGame : TurnStep
    {
        private IGameStarted Handler { get; }

        public StartGame(IPrimitiveGame game, IGameStarted handler) : base(game)
        {
            Handler = handler;
        }

        public override void Execute()
        {
            if (Game.IsGameStarted) return;

            Game.IsGameStarted = true;
            Game.Token.DecideStarterPlayerIndex();
            Handler.OnGameStarted(Game.Token.StarterPlayer);
        }
    }
}