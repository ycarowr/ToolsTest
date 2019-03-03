using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiPlayerContainer : MonoBehaviour, IUiPlayer
    {
        [Tooltip("Position of the UI on the Screen. Assigned by the Editor.")] [SerializeField]
        private PlayerSeat seat;
        public PlayerSeat Seat => seat;
        
        public bool IsMyTurn()
        {
            return GameController.Instance.IsCurrentPlayerOnSeat(Seat);
        }

        public TurnState GetPlayer()
        {
            return GameController.Instance.GetPlayer(Seat);
        }

        public bool IsAi()
        {
            return GetPlayer().IsAi;
        }
    }
}