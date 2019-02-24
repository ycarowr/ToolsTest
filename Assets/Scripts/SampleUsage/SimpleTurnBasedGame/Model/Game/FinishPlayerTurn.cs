﻿using System;
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
        public FinishPlayerTurn(IPrimitiveGame game) : base(game)
        {

        }


        /// <summary>
        /// Finish player turn logic.
        /// </summary>
        public void Execute()
        {
            if (!Game.IsTurnInProgress) return;
            if (!Game.IsGameStarted) return;
            if (Game.IsGameFinished) return;

            Game.IsTurnInProgress = false;
            Game.Token.CurrentPlayer.FinishTurn();
            OnFinishedCurrentPlayerTurn(Game.Token.CurrentPlayer);
        }

        /// <summary>
        /// Dispatch to the listeners.
        /// </summary>
        /// <param name="currentPlayer"></param>
        private void OnFinishedCurrentPlayerTurn(IPrimitivePlayer currentPlayer)
        {
            GameEvents.Instance.Notify<IFinishPlayerTurn>(i => i.OnFinishPlayerTurn(currentPlayer));
        }
    }
}