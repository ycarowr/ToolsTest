using System.Collections.Generic;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     Small Part of Turn.
    /// </summary>
    public abstract class TurnStep
    {
        /// <summary>
        /// All game data.
        /// </summary>
        protected IPrimitiveGame Game { get; set; }

        protected TurnStep(IPrimitiveGame game)
        {
            Game = game;
        }

        /// <summary>
        ///     Execution of this turn step.
        /// </summary>
        public abstract void Execute();
    }
}