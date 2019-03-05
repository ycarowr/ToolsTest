using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiPlayerContainer : MonoBehaviour, IUiPlayer
    {
        [field: Tooltip("Position of the UI on the Screen. Assigned by the Editor.")]
        [field: SerializeField]
        public PlayerSeat Seat { get; }

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