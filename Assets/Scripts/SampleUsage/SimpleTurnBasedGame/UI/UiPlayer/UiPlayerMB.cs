using System.Collections.Generic;
using Extensions;
using Patterns;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleTurnBasedGame
{
    public class UiPlayerMB : MonoBehaviour, IUiPlayer
    {
        [Tooltip("Position of the UI on the Screen. Assigned by the Editor.")]
        [SerializeField] private PlayerSeat seat;
        public PlayerSeat Seat => seat;

        public UiPlayer UiPlayer { get; protected set;}

        protected virtual void Awake()
        {
            UiPlayer = new UiPlayer(this);
        }

        protected virtual void Start()
        {
            ObserverGameEvents.Instance.AddListener(this);
        }

        protected virtual void OnDestroy()
        {
            if(ObserverGameEvents.Instance)
                ObserverGameEvents.Instance.RemoveListener(this);
        }

        #region Game Events

        public virtual void OnPreGameStart(List<IPrimitivePlayer> players)
        {
            Debug.Log(name);
            UiPlayer.OnPreGameStart(players);
        }

        public virtual void OnStartGame(IPrimitivePlayer starter)
        {
            UiPlayer.OnStartGame(starter);
        }

        public virtual void OnFinishGame(IPrimitivePlayer winner)
        {
            UiPlayer.OnFinishGame(winner);
        }

        public virtual void OnFinishedCurrentPlayerTurn(IPrimitivePlayer player)
        {
            UiPlayer.OnFinishedCurrentPlayerTurn(player);
        }

        public virtual void OnStartPlayerTurn(IPrimitivePlayer player)
        {
            UiPlayer.OnStartPlayerTurn(player);
        }

        #endregion
    }
}