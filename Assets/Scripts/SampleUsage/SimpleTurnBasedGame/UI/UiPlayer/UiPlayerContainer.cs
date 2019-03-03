﻿using System.Collections.Generic;
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
            return GameController.Instance.IsCurrentPlayerOnSeat(seat);
        }

        public TurnState GetPlayer()
        {
            return GameController.Instance.GetPlayer(seat);
        }

        public bool IsAi()
        {
            return GetPlayer().IsAi;
        }
    }
}