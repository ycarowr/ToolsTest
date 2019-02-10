using UnityEngine;

namespace Patterns
{
    public abstract class StateMB<T> : MonoBehaviour where T : MonoBehaviour
    {
        /// <summary>
        /// Reference for the parent Finite StateMB Machine
        /// </summary>
        public StateMachineMB<T> FSM { get; private set; }

        /// <summary>
        /// Called by the FSM's Awake
        /// </summary>
        public virtual void OnAwake()
        {
            Log("OnAwake!");
        }

        /// <summary>
        /// Called by the FSM's Start
        /// </summary>
        public virtual void OnStart()
        {
            Log("OnStart!");
        }

        /// <summary>
        /// Called by the FSM's Update
        /// </summary>
        public virtual void OnUpdate()
        {
            Log("OnUpdate!");
        }

        /// <summary>
        /// Called right after enter the state
        /// </summary>
        public virtual void OnEnterState()
        {
            Log("OnEnterState <---------", "green");
        }

        /// <summary>
        /// Called right after left the state
        /// </summary>
        public virtual void OnExitState()
        {
            Log("OnExitState <---------", "red");
        }


        /// <summary>
        /// Setter for Internal StateMB Machine
        /// </summary>
        /// <param name="stateMachineMb"></param>
        public void InjectStateMachine(StateMachineMB<T> stateMachineMb)
        {
            FSM = stateMachineMb;
            Log("FSM Assigned");
        }


        private void Log(string log, string colorName = "black")
        {
            if (FSM.EnableLogs)
            {
                log = string.Format("[" + GetType() + "]: <color={0}><b>" + log + "</b></color>", colorName);
                Debug.Log(log);
            }
        }
    }
}
