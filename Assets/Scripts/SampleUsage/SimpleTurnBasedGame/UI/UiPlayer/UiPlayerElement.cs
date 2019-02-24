using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiPlayerElement : MonoBehaviour, IUiPlayer
    {
        private UiPlayerContainer Handler { get; set; }
        public PlayerSeat Seat => Handler.Seat;

        private void Awake()
        {
            Handler = GetComponentInParent<UiPlayerContainer>();
        }
    }
}