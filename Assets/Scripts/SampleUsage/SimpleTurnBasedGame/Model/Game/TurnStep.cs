using System.Collections.Generic;
using Patterns;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     Small Part of a Turn.
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
    }
}