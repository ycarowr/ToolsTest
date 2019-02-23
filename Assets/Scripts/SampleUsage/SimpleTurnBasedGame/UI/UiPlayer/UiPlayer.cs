using System.Collections.Generic;
using Extensions;
using Patterns;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleTurnBasedGame
{
    public class UiPlayer : UiPlayerBase
    {
        private IUiPlayerUpdateView[] UiPlayerUpdateViews { get; }
        private CanvasGroup CanvasGroup { get; }

        public UiPlayer(UiPlayerMB handler) : base(handler)
        {
            UiPlayerUpdateViews = handler.GetComponentsInChildren<IUiPlayerUpdateView>();
            CanvasGroup = handler.GetComponent<CanvasGroup>();
        }

        protected bool IsMyTurn()
        {
            return TurnBasedController.Instance.IsMyTurn(Seat);
        }

        public override void OnPreGameStart(List<IPrimitivePlayer> players)
        {
            var myPlayer = players.Find(x => x.Seat == Seat);
            for (var i = 0; i < UiPlayerUpdateViews.Length; i++)
            {
                var component = UiPlayerUpdateViews[i];
                component.UpdatePlayer(myPlayer);
            }
        }
    }
}