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

        void UiButtonRandom.IPressRandom.DoRandomMove()
        {
            var player = Handler.GetPlayer();
            if (player.ProcessMove(MoveType.RandomMove))
                DisableInput();
        }

        void UiButtonHeal.IPressHeal.DoHealMove()
        {
            var player = Handler.GetPlayer();
            if (player.ProcessMove(MoveType.HealMove))
                DisableInput();
        }

        void UiButtonDamage.IPressDamage.DoDamageMove()
        {
            var player = Handler.GetPlayer();
            if (player.ProcessMove(MoveType.DamageMove))
                DisableInput();
        }

        private void DisableInput()
        {
            Handler.UiPlayerUserInput.DisableInput();
        }
    }
}