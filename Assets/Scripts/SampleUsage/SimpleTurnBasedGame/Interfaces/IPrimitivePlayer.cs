namespace SimpleTurnBasedGame
{
    public interface IPrimitivePlayer
    {
        PlayerSeat Seat { get; }
        void DrawStartingHand();
        void StartTurn();
        void FinishTurn();
    }
}