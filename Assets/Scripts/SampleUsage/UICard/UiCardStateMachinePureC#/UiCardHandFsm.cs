using Patterns.StateMachine;
using UnityEngine;

namespace Tools.UI.Card
{
    /// <summary>
    ///     State Machine that holds all states of a UI Card.
    /// </summary>
    public class UiCardHandFsm : BaseStateMachine
    {
        //--------------------------------------------------------------------------------------------------------------

        #region Constructor
        
        public UiCardHandFsm(Camera camera, UiCardParameters cardConfigsParameters, IUiCard handler = null) :
            base(handler)
        {
            CardConfigsParameters = cardConfigsParameters;

            IdleState = new UiCardIdle(handler, this, CardConfigsParameters);
            DisableState = new UiCardDisable(handler, this, CardConfigsParameters);
            DragState = new UiCardDrag(handler, camera, this, CardConfigsParameters);
            HoverState = new UiCardHover(handler, this, CardConfigsParameters);

            RegisterState(IdleState);
            RegisterState(DisableState);
            RegisterState(DragState);
            RegisterState(HoverState);

            Initialize();
        }
        
        #endregion

        //--------------------------------------------------------------------------------------------------------------
        
        #region Properties
        
        private UiCardIdle IdleState { get; }
        private UiCardDisable DisableState { get; }
        private UiCardDrag DragState { get; }
        private UiCardHover HoverState { get; }
        private UiCardParameters CardConfigsParameters { get; }
        
        #endregion
        
        //--------------------------------------------------------------------------------------------------------------
        
        #region Operations

        public void Hover()
        {
            PushState<UiCardHover>();
        }

        public void Disable()
        {
            PushState<UiCardDisable>();
        }

        public void Enable()
        {
            PushState<UiCardIdle>();
        }

        public void Select()
        {
            PushState<UiCardDrag>();
        }

        public void Unselect()
        {
            Enable();
        }
        
        #endregion
        
        //--------------------------------------------------------------------------------------------------------------
    }
}