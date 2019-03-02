
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiButtonDamage: UiButton
    {
        public interface IPressDamage : IButtonHandler
        {
            void PressDamageMove();
        }

        protected override void OnSetHandler(IButtonHandler handler)
        {
            if (handler is IPressDamage passTurn)
                AddListener(passTurn.PressDamageMove);
        }
    }
}
