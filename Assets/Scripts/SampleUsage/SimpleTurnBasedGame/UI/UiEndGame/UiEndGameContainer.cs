using System.Collections;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public interface IRestartGameHandler
    {
        void RestartGame();
    }

    /// <summary>
    ///     End game HUD. Solves model dependencies accessing the game controller via Singleton.
    /// </summary>
    [RequireComponent(typeof(IUiUserInput))]
    public class UiEndGameContainer : UiListener, 
        IRestartGameHandler,
        IFinishGame,
        IStartGame,
        IUiController
    {
        //----------------------------------------------------------------------------------------------------------

        #region Properties

        private const float DelayToEnable = 1f;
        private IUiUserInput UserInput { get; set; }
        public IGameController GameController => ControllerCs.GameController.Instance;

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Game Events

        void IFinishGame.OnFinishGame(IPrimitivePlayer winner)
        {
            StartCoroutine(EnableInput());
        }

        void IStartGame.OnStartGame(IPrimitivePlayer starter)
        {
            UserInput.Disable();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Unity Callbacks

        private void Awake()
        {
            //user input
            UserInput = gameObject.AddComponent<UiUserInput>();

            //HUD end game
            gameObject.AddComponent<UiButtonsEndGame>();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        void IRestartGameHandler.RestartGame()
        {
            GameController.RestartGameImmediately();
        }

        private IEnumerator EnableInput()
        {
            yield return new WaitForSeconds(DelayToEnable);
            UserInput.Enable();
        }
    }
}