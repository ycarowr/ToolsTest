
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiButtonDamage: UiButton
    {
        public interface IPressDamage : IButtonHandler
        {
            void DoDamageMove();
        }

        public override void SetHandler(IButtonHandler handler)
        {
            if (handler is IPressDamage passTurn)
                AddListener(passTurn.DoDamageMove);
        }
    }
}
