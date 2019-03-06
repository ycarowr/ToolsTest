using UnityEngine;

namespace SimpleTurnBasedGame
{
    [RequireComponent(typeof(IUiEndGameController))]
    public class UiButtonsEndGame : MonoBehaviour,
        IButtonHandler,
        UiButtonRestart.IPressRestart
    {
        void UiButtonRestart.IPressRestart.PressRestart()
        {
            PlayerController.RestartGame();
        }

        private IUiEndGameController PlayerController { get; set; }

        private void Awake()
        {
            PlayerController = GetComponent<IUiEndGameController>();

            var buttons = gameObject.GetComponentsInChildren<UiButton>();
            foreach (var button in buttons)
                button.SetHandler(this);
        }
    }
}