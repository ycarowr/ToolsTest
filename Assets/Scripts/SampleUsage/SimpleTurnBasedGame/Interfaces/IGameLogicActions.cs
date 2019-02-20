namespace SimpleTurnBasedGame
{
    public interface IGameLogicActions
    {
        void OnGameStarted(IPrimitivePlayer starter);
        void OnGameFinished(IPrimitivePlayer winner);
        void OnStartedCurrentPlayerTurn(IPrimitivePlayer player);
        void OnFinishedCurrentPlayerTurn(IPrimitivePlayer player);
    }
}