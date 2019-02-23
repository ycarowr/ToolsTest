using System.Collections.Generic;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiPlayerUser : UiPlayer
    {
        private CanvasGroup CanvasGroup { get; }
        private UiButtonPassTurn ButtonPassTurn { get; }

        public UiPlayerUser(UiPlayerMB handler) : base(handler)
        {
            CanvasGroup = handler.GetComponent<CanvasGroup>();
            ButtonPassTurn = handler.GetComponentInChildren<UiButtonPassTurn>();
            ButtonPassTurn.AddListener(TryPassTurn);
        }

        public override void OnPreGameStart(List<IPrimitivePlayer> players)
        {
            base.OnPreGameStart(players);
            DisableUi();
        }

        public override void OnStartPlayerTurn(IPrimitivePlayer player)
        {
            base.OnStartPlayerTurn(player);

            if (IsMyTurn())
                EnableUi();
        }

        public override void OnFinishedCurrentPlayerTurn(IPrimitivePlayer player)
        {
            base.OnFinishedCurrentPlayerTurn(player);
            
            if (IsMyTurn())
                DisableUi();
        }

        private void DisableUi()
        {
            CanvasGroup.interactable = false;
        }

        private void EnableUi()
        {
            CanvasGroup.interactable = true;
        }

        private void TryPassTurn()
        {
            var player = TurnBasedController.Instance.GetPlayer(Seat);
            if(player.TryPassTurn())
                DisableUi();
        }
    }
}