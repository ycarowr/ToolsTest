using System.Collections.Generic;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiPlayerUserButtons : UiPlayerUserBase,
        UiButtonRandom.IPressRandom, 
        UiButtonDamage.IPressDamage, 
        UiButtonHeal.IPressHeal
    {

        public UiPlayerUserButtons(UiPlayerUserContainer handler) : base(handler)
        {
            var buttons = handler.GetComponentsInChildren<UiButton>();
            foreach (var button in buttons)
                button.SetHandler(this);
        }

        void UiButtonRandom.IPressRandom.Random()
        {
            var player = Handler.GetPlayer();
            if (player.TryRandom())
                DisableInput();
        }

        void UiButtonHeal.IPressHeal.PressHeal()
        {
            var player = Handler.GetPlayer();
            if (player.TryHeal())
                DisableInput();
        }

        void UiButtonDamage.IPressDamage.PressDamage()
        {
            var player = Handler.GetPlayer();
            if (player.TryDamage())
                DisableInput();
        }

        private void DisableInput()
        {
            Handler.UiPlayerUserInput.DisableInput();
        }
    }
}