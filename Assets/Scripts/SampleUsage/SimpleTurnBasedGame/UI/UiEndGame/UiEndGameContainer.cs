using UnityEngine;
using UnityEngine.SceneManagement;

namespace SimpleTurnBasedGame
{
    /// <summary>
    /// End game HUD.
    /// </summary>
    public class UiEndGameContainer : UiListener, 
        IUiCanvasGroupHandler, 
        IFinishGame,
        IStartGame
    {
        public UiButtonsEndGame UiEndGameButtons { get; private set; }
        public UiCanvasGroupInput UiEndGameInput { get; private set; }

        CanvasGroup IUiCanvasGroupHandler.CanvasGroup => GetComponent<CanvasGroup>();

        private void Awake()
        {
            UiEndGameInput = new UiCanvasGroupInput(this);
            UiEndGameButtons = new UiButtonsEndGame(this);
        }

        void IFinishGame.OnFinishGame(IPrimitivePlayer winner)
        {
            UiEndGameInput.Enable();
        }

        void IStartGame.OnStartGame(IPrimitivePlayer starter)
        {
            UiEndGameInput.Disable();
        }
    }
}