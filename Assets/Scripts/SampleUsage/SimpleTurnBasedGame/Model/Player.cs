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
            throw new System.NotImplementedException();
        }

        void IPrimitivePlayer.FinishTurn()
        {
            throw new System.NotImplementedException();
        }

        void IPrimitivePlayer.StartTurn()
        {
            throw new System.NotImplementedException();
        }
    }
}