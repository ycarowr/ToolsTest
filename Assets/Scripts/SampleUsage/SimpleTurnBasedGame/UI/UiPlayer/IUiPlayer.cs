using System.Collections;
using System.Collections.Generic;
using Patterns;
using SimpleTurnBasedGame;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public interface IUiPlayer :
        IListener,
        IPreGameStart,
        IStartGame,
        IFinishGame,
        IStartPlayerTurn,
        IFinishedPlayerTurn
    {
        PlayerSeat Seat { get; }
    }

    public interface IUiPlayerUpdateView
    {
        void UpdatePlayer(IPrimitivePlayer player);
    }
}