using System.Collections;
using Patterns;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     The base of all the Game States. It provides access to the Game implementation.
    /// </summary>
    public abstract class BaseBattleState : StateMB<TurnBasedController>, IRuntimeGameRegister
    {
        protected IPrimitiveGame RuntimeGame { get; set; }

        public virtual void RegisterRuntimeGame(IPrimitiveGame game)
        {
            RuntimeGame = game;
        }

        protected virtual void OnNext(BaseBattleState nextState)
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