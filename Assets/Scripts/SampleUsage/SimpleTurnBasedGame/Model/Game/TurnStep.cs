namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     Small Part of a Turn.
    /// </summary>
    public abstract class TurnStep
    {
        protected TurnStep(IPrimitiveGame game)
        {
            Game = game;
        }

        /// <summary>
        ///     All game data.
        /// </summary>
        protected IPrimitiveGame Game { get; set; }
    }
}