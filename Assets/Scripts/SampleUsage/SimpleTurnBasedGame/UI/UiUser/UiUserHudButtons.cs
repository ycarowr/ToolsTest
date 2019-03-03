namespace SimpleTurnBasedGame
{
    public class UiUserHudButtons :
        IUiUserContainerHandler,
        UiButtonRandom.IPressRandom,
        UiButtonDamage.IPressDamage,
        UiButtonHeal.IPressHeal
    {
        public UiUserHudButtons(IUiUserContainerHandler handler)
        {
            Container = handler.Container;

            //find all buttons
            var buttons = Container.GetComponentsInChildren<UiButton>();

            //set this as a handler
            foreach (var button in buttons)
                button.SetHandler(this);
        }

        void UiButtonDamage.IPressDamage.PressDamageMove()
        {
            var player = Container.GetPlayer();
            if (player.ProcessMove(MoveType.DamageMove))
                DisableInput();
        }

        void UiButtonHeal.IPressHeal.PressHealMove()
        {
            var player = Container.GetPlayer();
            if (player.ProcessMove(MoveType.HealMove))
                DisableInput();
        }

        void UiButtonRandom.IPressRandom.PressRandomMove()
        {
            var player = Container.GetPlayer();
            if (player.ProcessMove(MoveType.RandomMove))
                DisableInput();
        }

        public UiUserContainer Container { get; }

        private void DisableInput()
        {
            Container.UiUserHudInput.Disable();
        }
    }
}