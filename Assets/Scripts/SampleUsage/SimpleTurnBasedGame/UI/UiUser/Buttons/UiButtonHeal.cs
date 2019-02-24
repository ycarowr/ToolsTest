
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiButtonHeal : UiButton
    {
        public interface IPressHeal : IButtonHandler
        {
            void PressHeal();
        }

        public override void SetHandler(IButtonHandler handler)
        {
            if (handler is IPressHeal passTurn)
                AddListener(passTurn.PressHeal);
        }
    }
}
