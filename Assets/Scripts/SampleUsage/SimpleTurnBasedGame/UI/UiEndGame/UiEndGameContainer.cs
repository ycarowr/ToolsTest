using System.Collections;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     End game HUD.
    /// </summary>
    public class UiEndGameContainer : UiListener,
        IUiCanvasGroupHandler,
        IFinishGame,
        IStartGame
    {
        private const float DelayToEnable = 1f;
        CanvasGroup IUiCanvasGroupHandler.CanvasGroup => GetComponent<CanvasGroup>();
        public UiButtonsEndGame UiEndGameButtons { get; private set; }
        public UiCanvasGroupInput UiEndGameInput { get; private set; }

        void IFinishGame.OnFinishGame(IPrimitivePlayer winner)
        {
            StartCoroutine(EnableInput());
        }

        void IStartGame.OnStartGame(IPrimitivePlayer starter)
        {
            UiEndGameInput.Disable();
        }
        
        private void Awake()
        {
            UiEndGameInput = new UiCanvasGroupInput(this);
            UiEndGameButtons = new UiButtonsEndGame(this);
        }

        private IEnumerator EnableInput()
        {
            yield return new WaitForSeconds(DelayToEnable);
            UiEndGameInput.Enable();
        }
    }
}