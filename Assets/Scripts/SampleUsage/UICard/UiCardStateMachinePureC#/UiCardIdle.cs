using Patterns.StateMachine;
using UnityEngine.EventSystems;

namespace Tools.UI.Card
{
    /// <summary>
    ///     UI Card Idle behavior.
    /// </summary>
    public class UiCardIdle : UiBaseCardState
    {
        //--------------------------------------------------------------------------------------------------------------
        
        public UiCardIdle(IUiCard handler, BaseStateMachine fsm, UiCardParameters parameters) : base(handler, fsm, parameters)
        {
            Handler.Input.OnPointerDown += OnPointerDown;
            Handler.Input.OnPointerEnter += OnPointerEnter;
        }
        
        //--------------------------------------------------------------------------------------------------------------

        public override void OnEnterState()
        {
            Handler.UiCardMovement.OnArrive += Enable;
            MakeRenderNormal();
        }

        public override void OnExitState()
        {
            Handler.UiCardMovement.OnArrive -= Enable;
        }
        //--------------------------------------------------------------------------------------------------------------

        private void OnPointerEnter(PointerEventData obj)
        {
            if (Fsm.IsCurrent(this))
                Handler.Hover();
        }

        private void OnPointerDown(PointerEventData eventData)
        {
            if (Fsm.IsCurrent(this))
                Handler.Select();
        }
        
        //--------------------------------------------------------------------------------------------------------------
    }
}