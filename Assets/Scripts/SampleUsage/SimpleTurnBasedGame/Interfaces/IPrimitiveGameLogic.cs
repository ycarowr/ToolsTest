namespace SimpleTurnBasedGame
{
    public interface IPrimitiveGameLogic
    {
        ITokenCurrentPlayer Token { get; }

        bool IsGameStarted { get; }

        bool IsGameFinished { get; }

        bool IsTurnInProgress { get; }

        void StartGame();

        void StartCurrentPlayerTurn();

        void FinishCurrentPlayerTurn();

        void FinishGame();
    }
}