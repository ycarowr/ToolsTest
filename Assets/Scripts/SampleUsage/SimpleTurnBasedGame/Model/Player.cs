namespace SimpleTurnBasedGame
{
    /// <summary>
    /// Simple concrete player class.
    /// </summary>
    public class Player : IPrimitivePlayer
    {
        public PlayerSeat Seat { get; }
        public int Health { get; }

        private const int DefaultMaxHealth = 5;

        public Player(PlayerSeat seat)
        {
            Seat = seat;
            Health = DefaultMaxHealth;
        }

        void IPrimitivePlayer.FinishTurn()
        {

        }

        void IPrimitivePlayer.StartTurn()
        {

        }
    }
}