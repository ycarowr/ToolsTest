using System.Collections.Generic;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     Start Current Player Turn Implementation.
    /// </summary>
    public class StartPlayerTurn : TurnStep
    {
        private IStartedPlayerTurn Handler { get; }

        public StartPlayerTurn(IPrimitiveGame game, IStartedPlayerTurn handler) : base(game)
        {
            Handler = handler;
        }

        public override void Execute()
        {
            if (Game.IsTurnInProgress)
                return;
            if (!Game.IsGameStarted)
                return;
            if (Game.IsGameFinished)
                return;

            Game.IsTurnInProgress = true;
            Game.Token.UpdateCurrentPlayerIndex();
            Game.Token.CurrentPlayer.StartTurn();
            Handler.OnStartedCurrentPlayerTurn(Game.Token.CurrentPlayer);
        }
    }
}