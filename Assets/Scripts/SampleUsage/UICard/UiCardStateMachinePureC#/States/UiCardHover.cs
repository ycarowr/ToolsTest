using Patterns.StateMachine;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tools.UI.Card
{
    public class UiCardHover : UiBaseCardState
    {
        //--------------------------------------------------------------------------------------------------------------
        
        public UiCardHover(IUiCard handler, BaseStateMachine fsm, UiCardParameters parameters) : base(handler, fsm, parameters)
        {
        }
        
        //--------------------------------------------------------------------------------------------------------------
        
        #region Properties
        
        private Vector3 StartPosition { get; set; }
        private Vector3 StartEuler { get; set; }
        private Vector3 StartScale { get; set; }

        #endregion
        
        //--------------------------------------------------------------------------------------------------------------
        
        #region Operations
        
        public override void OnEnterState()
        {
            MakeRenderFirst();
            SubscribeInput();
            CachePreviousValues();
            SetScale();
            SetPosition();
            SetRotation();
        }

        public override void OnExitState()
        {
            UnsubscribeInput();
            ResetValues();
        }

        

        #endregion
        
        //--------------------------------------------------------------------------------------------------------------

        private void OnPointerExit(PointerEventData obj)
        {
            if (Fsm.IsCurrent(this))
                Handler.Enable();
        }

        private void OnPointerDown(PointerEventData eventData)
        {
            if (Fsm.IsCurrent(this))
                Handler.Select();
        }
        
        //--------------------------------------------------------------------------------------------------------------
        
        private void ResetValues()
        {
            Handler.RotateTo(StartEuler);
            Handler.MoveTo(StartPosition);
            Handler.Transform.localScale = StartScale;
        }
        
        private void SetRotation()
        {
            if (!Parameters.HoverRotation)
                Handler.RotateTo(Vector3.zero);
        }

        private void SetPosition()
        {
            var halfCardHeight = new Vector3(0, Handler.MyRenderer.bounds.size.y / 2);
            var pointZeroScreen = Handler.MainCamera.ScreenToWorldPoint(Vector3.zero);
            var bottomScreenY = new Vector3(0, pointZeroScreen.y);
            var currentPosWithoutY = new Vector3(Handler.transform.position.x, 0, Handler.transform.position.z);
            var hoverHeightParameter = new Vector3(0, Parameters.HoverHeight);
            var final = currentPosWithoutY + bottomScreenY + halfCardHeight + hoverHeightParameter;
            Handler.MoveTo(final);
        }

        private void SetScale()
        {
            Handler.Transform.localScale *= Parameters.HoverScale;
        }

        private void CachePreviousValues()
        {
            StartPosition = Handler.Transform.position;
            StartEuler = Handler.Transform.eulerAngles;
            StartScale = Handler.Transform.localScale;
        }

        private void SubscribeInput()
        {
            Handler.Input.OnPointerExit += OnPointerExit;
            Handler.Input.OnPointerDown += OnPointerDown;
        }

        private void UnsubscribeInput()
        {
            Handler.Input.OnPointerExit -= OnPointerExit;
            Handler.Input.OnPointerDown -= OnPointerDown;
        }
    }
}