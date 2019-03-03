using System.Collections.Generic;
using Patterns;

namespace SimpleTurnBasedGame
{
    public class UiButtonRestart : UiButton,
        IListener,
        IPreGameStart,
        IFinishGame
    {
        void IFinishGame.OnFinishGame(IPrimitivePlayer winner)
        {
            gameObject.SetActive(true);
        }

        void IPreGameStart.OnPreGameStart(List<IPrimitivePlayer> players)
        {
            gameObject.SetActive(false);
        }

        private void Start()
        {
            GameEvents.Instance.AddListener(this);
        }

        private void OnDestroy()
        {
            if (GameEvents.Instance)
                GameEvents.Instance.RemoveListener(this);
        }

        protected override void OnSetHandler(IButtonHandler handler)
        {
            if (handler is IPressRestart restart)
                AddListener(restart.PressRestart);
        }

        public interface IPressRestart
        {
            void PressRestart();
        }
    }
}