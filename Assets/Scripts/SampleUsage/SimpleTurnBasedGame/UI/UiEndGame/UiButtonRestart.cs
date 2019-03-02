using System.Collections;
using System.Collections.Generic;
using Patterns;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SimpleTurnBasedGame
{
    public class UiButtonRestart : UiButton, 
        IListener, 
        IPreGameStart,
        IFinishGame
    {
        public interface IPressRestart
        {
            void PressRestart();
        }

        private void Start()
        {
            GameEvents.Instance.AddListener(this);
        }

        private void OnDestroy()
        {
            if(GameEvents.Instance)
                GameEvents.Instance.RemoveListener(this);
        }

        protected override void OnSetHandler(IButtonHandler handler)
        {
            if(handler is IPressRestart restart)
                AddListener(restart.PressRestart);
        }

        void IPreGameStart.OnPreGameStart(List<IPrimitivePlayer> players)
        {
            gameObject.SetActive(false);
        }

        void IFinishGame.OnFinishGame(IPrimitivePlayer winner)
        {
            gameObject.SetActive(true);
        }
    }
}
