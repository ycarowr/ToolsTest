namespace SimpleTurnBasedGame
{
    public interface IPrimitivePlayer
    {
        PlayerSeat Seat { get; }
        int Health { get; }
        void StartTurn();
        void FinishTurn();
    }
}