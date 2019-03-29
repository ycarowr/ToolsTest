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
        private Quaternion StartRotation { get; set; }
        private Vector3 StartScale { get; set; }

        #endregion
        
        //--------------------------------------------------------------------------------------------------------------
        
        #region Operations
        
        public override void OnEnterState()
        {
            MakeRenderFirst();

            Handler.Input.OnPointerExit += OnPointerExit;
            Handler.Input.OnPointerDown += OnPointerDown;

            //cache old values
            StartPosition = Handler.Transform.position;
            StartRotation = Handler.Transform.rotation;
            StartScale = Handler.Transform.localScale;

            Debug.Log(Handler);
            Debug.Log(Parameters);
            Handler.Transform.localPosition += new Vector3(0, Parameters.HoverHeight, 0);
            Handler.Transform.localScale *= Parameters.HoverScale;

            if (!Parameters.HoverRotation)
                Handler.Transform.localRotation = Quaternion.identity;
        }

        public override void OnExitState()
        {
            Handler.Input.OnPointerExit -= OnPointerExit;
            Handler.Input.OnPointerDown -= OnPointerDown;

            //reset position and rotation
            Handler.Transform.rotation = StartRotation;
            Handler.Transform.position = StartPosition;
            Handler.Transform.localScale = StartScale;
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
    }
}