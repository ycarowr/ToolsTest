using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UIPlayer : MonoBehaviour, IPlayerStateRegister
    {
        public IPrimitivePlayer Player { get; private set; }

        [field: SerializeField] public PlayerSeat Seat { get; }

        void IPlayerStateRegister.RegisterPlayer(TurnState playerTurnState)
        {
            Player = playerTurnState.Player;
        }

        private void Awake()
        {
        }

        private void TryPassTurn()
        {
            register.Instance.TryPassTurn(Player);
        }
    }
}