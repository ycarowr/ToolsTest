namespace SimpleTurnBasedGame
{
    public interface IGameStarted
    {
        void OnGameStarted(IPrimitivePlayer starter);
    }

    public interface IGameFinished
    {
        void OnGameFinished(IPrimitivePlayer winner);
    }

    public interface IStartedPlayerTurn
    {
        void OnStartedCurrentPlayerTurn(IPrimitivePlayer player);
    }

    public interface IFinishedPlayerTurn
    {
        void OnFinishedCurrentPlayerTurn(IPrimitivePlayer player);
    }
}