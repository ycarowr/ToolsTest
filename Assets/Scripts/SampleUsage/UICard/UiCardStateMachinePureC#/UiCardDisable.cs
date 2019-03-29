using Patterns.StateMachine;

namespace Tools.UI.Card
{
    /// <summary>
    ///     This state disables the collider of the card.
    /// </summary>
    public class UiCardDisable : UiBaseCardState
    {
        public UiCardDisable(IUiCard handler, BaseStateMachine fsm, UiCardParameters parameters) : base(handler, fsm, parameters)
        {
        }
        
        //--------------------------------------------------------------------------------------------------------------
        
        #region Operations

        public override void OnEnterState()
        {
            Disable();
        }
        
        #endregion
        
        //--------------------------------------------------------------------------------------------------------------
        
        /// <summary>
        ///     Disabled state of the card.
        /// </summary>
        private void Disable()
        {
            Handler.Collider.enabled = false;
            Handler.Rigidbody.Sleep();
            MakeRenderNormal();
            foreach (var renderer in Handler.Renderers)
            {
                var myColor = renderer.color;
                myColor.a = Parameters.DisabledAlpha;
                renderer.color = myColor;
            }
        }
    }
}