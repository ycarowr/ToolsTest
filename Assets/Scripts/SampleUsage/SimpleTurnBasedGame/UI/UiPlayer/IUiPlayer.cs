using System.Collections;
using System.Collections.Generic;
using Patterns;
using SimpleTurnBasedGame;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public interface IUiPlayer
    {
        PlayerSeat Seat { get; }
        bool IsMyTurn();
        TurnState GetPlayer();
    }
}