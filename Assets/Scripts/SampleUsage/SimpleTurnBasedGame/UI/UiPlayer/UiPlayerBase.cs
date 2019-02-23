using System.Collections.Generic;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public abstract class UiPlayerBase : IUiPlayer
    {
        protected UiPlayerMB Handler { get; }

        public PlayerSeat Seat => Handler.Seat;

        protected UiPlayerBase(UiPlayerMB handler)
        {
            Handler = handler;
        }

        #region Game Events

        public virtual void OnPreGameStart(List<IPrimitivePlayer> players)
        {

        }

        public virtual void OnStartGame(IPrimitivePlayer starter)
        {
            Debug.Log("Ui Received Message: Start Game by player " + starter.Seat);
        }

        public virtual void OnFinishGame(IPrimitivePlayer winner)
        {
            Debug.Log("Ui Received Message: Finish Game: " + winner.Seat);
        }

        public virtual void OnFinishedCurrentPlayerTurn(IPrimitivePlayer player)
        {
            Debug.Log("Ui Received Message: Finished Player Turn: " + player.Seat);
        }

        public virtual void OnStartPlayerTurn(IPrimitivePlayer player)
        {
            Debug.Log("Ui Received Message: Started player turn: " + player.Seat);
        }

        #endregion
    }
}