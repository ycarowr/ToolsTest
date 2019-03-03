namespace SimpleTurnBasedGame
{
    public interface IPrimitiveGame
    {
        ITokenTurnLogic Token { get; }

        bool IsGameStarted { get; set; }

        bool IsGameFinished { get; set; }

        bool IsTurnInProgress { get; set; }

        int TurnTime { get; set; }

        int TotalTime { get; set; }
    }
}