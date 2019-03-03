using System.Collections;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class BottomPlayerState : AiTurnState
    {
        public override PlayerSeat Seat => PlayerSeat.Bottom;
    }
}

