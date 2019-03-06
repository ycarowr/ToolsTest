using System.Collections;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public interface IUiEndGameController
    {
        void RestartGame();
    }

    /// <summary>
    ///     End game HUD.
    /// </summary>
    [RequireComponent(typeof(IUiUserInput))]
    public class UiEndGameContainer : UiListener, IUiEndGameController,
        IFinishGame,
        IStartGame
    {
        private const float DelayToEnable = 1f;
        private IUiUserInput UserInput { get; set; }

        void IUiEndGameController.RestartGame() => GameController.Instance.RestartGameImmediately();

        void IFinishGame.OnFinishGame(IPrimitivePlayer winner)
        {
            StartCoroutine(EnableInput());
        }

        void IStartGame.OnStartGame(IPrimitivePlayer starter)
        {
            UserInput.Disable();
        }

        private void Awake()
        {
            //user input
            UserInput = gameObject.AddComponent<UiUserInput>();

            //HUD end game
            gameObject.AddComponent<UiButtonsEndGame>();
        }

        private IEnumerator EnableInput()
        {
            yield return new WaitForSeconds(DelayToEnable);
            UserInput.Enable();
        }
    }
}