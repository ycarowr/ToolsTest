using UnityEngine.EventSystems;

namespace Tools.UI.Card
{
    public class UiCardHover : UiBaseCardState
    {
        public override void OnEnterState()
        {
            MakeRenderFirst();
            MyInput.OnPointerExit += OnPointerExit;
            MyInput.OnPointerDown += OnPointerDown;
        }

        public override void OnExitState()
        {
            MyInput.OnPointerExit -= OnPointerExit;
            MyInput.OnPointerDown -= OnPointerDown;
        }

        private void OnPointerExit(PointerEventData obj)
        {
            if (Fsm.IsCurrent(this))
                Fsm.PushState<UiCardIdle>();
        }

        private void OnPointerDown(PointerEventData eventData)
        {
            if (Fsm.IsCurrent(this))
                Fsm.SelectThisCard();
        }
    }
}