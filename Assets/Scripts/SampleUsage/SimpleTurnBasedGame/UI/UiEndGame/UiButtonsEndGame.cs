namespace SimpleTurnBasedGame
{
    public class UiButtonsEndGame :
        IUiEndGame,
        IButtonHandler,
        UiButtonRestart.IPressRestart
    {
        public UiButtonsEndGame(UiEndGameContainer buttonsContainer)
        {
            Container = buttonsContainer;
            SetHandlers();
        }

        void UiButtonRestart.IPressRestart.PressRestart()
        {
            GameController.Instance.RestartGameImmediately();
        }

        public UiEndGameContainer Container { get; }

        public void SetHandlers()
        {
            var buttons = Container.GetComponentsInChildren<UiButton>();
            foreach (var button in buttons)
                button.SetHandler(this);
        }
    }
}