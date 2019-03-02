
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiButtonHeal : UiButton
    {
        public interface IPressHeal : IButtonHandler
        {
            void PressHealMove();
        }

        protected override void OnSetHandler(IButtonHandler handler)
        {
            if (handler is IPressHeal passTurn)
                AddListener(passTurn.PressHealMove);
        }
    }
}
