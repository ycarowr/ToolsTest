namespace SimpleTurnBasedGame
{
    /// <summary>
    /// Simple concrete player class.
    /// </summary>
    public class Player : IPrimitivePlayer
    {
        public PlayerSeat Seat { get; private set; }

        public Player(PlayerSeat seat)
        {
            Seat = seat;
        }

        void IPrimitivePlayer.DrawStartingHand()
        {
            
        }

        void IPrimitivePlayer.FinishTurn()
        {

        }

        void IPrimitivePlayer.StartTurn()
        {

        }
    }
}