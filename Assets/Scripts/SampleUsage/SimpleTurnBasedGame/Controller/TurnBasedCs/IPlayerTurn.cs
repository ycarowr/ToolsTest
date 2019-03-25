namespace SimpleTurnBasedGame
{
    public interface IPlayerTurn
    {
        bool IsAi { get; }
        bool IsUser { get; }
        bool IsMyTurn { get; }
        PlayerSeat Seat { get; }
        bool ProcessMove(MoveType move);
        IPrimitivePlayer Player { get; }
    }
}