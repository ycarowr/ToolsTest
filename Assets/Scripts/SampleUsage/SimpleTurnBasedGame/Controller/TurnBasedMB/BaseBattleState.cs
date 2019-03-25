using Patterns;
using UnityEngine;

namespace SimpleTurnBasedGame.ControllerMB
{
    /// <summary>
    ///     The base of all the Game States. It provides access to the Game implementation.
    /// </summary>
    [RequireComponent(typeof(IGameData))]
    [RequireComponent(typeof(GameControllerMB))]
    public abstract class BaseBattleState : StateMB<GameControllerMB>, IListener
    {
        protected GameControllerMB GameController { get; private set; }
        protected IGameData GameData { get; private set; }

        public override void OnInitialize()
        {
            GameData = GetComponent<IGameData>();
            GameController = GetComponent<GameControllerMB>();
        }

        private void Start()
        {
            if (GameEvents.Instance)
                GameEvents.Instance.AddListener(this);
        }

        public void OnDestroy()
        {
            var gameEvents = GameEvents.Instance;
            if (gameEvents)
                gameEvents.RemoveListener(this);
        }

        protected virtual void OnNextState(BaseBattleState nextState)
        {
            Fsm.PopState();
            Fsm.PushState(nextState);
        }

        public void Log(string log, string colorName = "black")
        {
            log = string.Format("[" + GetType() + "]: <color={0}><b>" + log + "</b></color>", colorName);
            Debug.Log(log);
        }
    }
}