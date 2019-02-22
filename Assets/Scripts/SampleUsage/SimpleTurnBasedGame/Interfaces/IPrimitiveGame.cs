namespace SimpleTurnBasedGame
{
    public interface IPrimitiveGame
    {
        ITokenCurrentPlayer Token { get; }

        bool IsGameStarted { get; set; }

        bool IsGameFinished { get; set; }

        bool IsTurnInProgress { get; set; }
    }
}