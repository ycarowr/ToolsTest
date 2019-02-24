using System.Collections.Generic;
using Extensions;
using Patterns;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleTurnBasedGame
{
    public class UiPlayerContainer : MonoBehaviour, IUiPlayer
    {
        [Tooltip("Position of the UI on the Screen. Assigned by the Editor.")]
        [SerializeField] private PlayerSeat seat;
        public PlayerSeat Seat => seat;

        public bool IsMyTurn()
        {
            return TurnBasedController.Instance.IsMyTurn(seat);
        }

        public TurnState GetPlayer()
        {
            return TurnBasedController.Instance.GetPlayer(seat);
        }
    }
}