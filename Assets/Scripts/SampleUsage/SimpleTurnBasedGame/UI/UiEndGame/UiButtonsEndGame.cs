using UnityEngine;
using UnityEngine.SceneManagement;

namespace SimpleTurnBasedGame
{
    public class UiButtonsEndGame: 
        IUiEndGame,
        IButtonHandler,
        UiButtonRestart.IPressRestart
    {
        public UiEndGameContainer Container { get; }


        public UiButtonsEndGame(UiEndGameContainer buttonsContainer)
        {
            Container = buttonsContainer;
            SetHandlers();
        }

        void UiButtonRestart.IPressRestart.PressRestart()
        {
            GameController.Instance.RestartGameImmediately();
        }

        public void SetHandlers()
        {
            var buttons = Container.GetComponentsInChildren<UiButton>();
            foreach (var button in buttons)
                button.SetHandler(this);
        }
    }
}