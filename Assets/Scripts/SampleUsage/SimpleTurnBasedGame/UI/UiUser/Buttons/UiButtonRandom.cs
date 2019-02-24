using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiButtonRandom : UiButton
    {
        public interface IPressRandom : IButtonHandler
        {
            void DoRandomMove();
        }

        public override void SetHandler(IButtonHandler handler)
        {
            if(handler is IPressRandom pressRandom)
                AddListener(pressRandom.DoRandomMove);
        }
    }
}
