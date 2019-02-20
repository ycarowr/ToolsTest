using Patterns;

namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     The base of all the Game States. It provides access to the GameLogic implementation.
    /// </summary>
    public abstract class BaseBattleState : StateMB<GameController>
    {
        //Game Logic implementation access
        protected IPrimitiveGameLogic GameLogic { get; private set; }

        public void InjectGameLogic(IPrimitiveGameLogic logic)
        {
            GameLogic = logic;
        }

        public virtual void Restart()
        {
        }
    }
}