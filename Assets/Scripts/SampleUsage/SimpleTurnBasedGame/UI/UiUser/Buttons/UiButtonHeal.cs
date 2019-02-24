
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiButtonHeal : UiButton
    {
        public interface IPressHeal : IButtonHandler
        {
            void DoHealMove();
        }

        public override void SetHandler(IButtonHandler handler)
        {
            if (handler is IPressHeal passTurn)
                AddListener(passTurn.DoHealMove);
        }
    }
}
