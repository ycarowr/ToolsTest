using System;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns
{
    /// <summary>
    /// This class registers and manages all the States of this specific 
    /// Type of State Machine that are attached to the same GameObject. All the states
    /// have to be assign to the gameobject BEFORE the Initialization. So if you are
    /// using AddComponent calls, be sure this is called before the State's registration.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class StateMachineMB<T> : MonoBehaviour where T : MonoBehaviour
    {
        public bool EnableLogs = false;

        //Push-Pop stack of States of this Type of Finite State Machine
        private readonly Stack<StateMB<T>> stack = new Stack<StateMB<T>>();

        //This register doesn't allowed you to have two states with the same Type
        private Dictionary<Type, StateMB<T>> register = new Dictionary<Type, StateMB<T>>();


        /// <summary>
        /// Register all the states
        /// </summary>
        protected virtual void Initialize()
        {
            //grab all states of this FSM Type attached to this gameobject
            var allStates = GetComponents<StateMB<T>>();

            //register all states
            foreach (var state in allStates)
            {
                var type = state.GetType();
                register.Add(type, state);
                state.InjectStateMachine(this);
            }

            Log("Initialized!", "green");
        }

        #region Unity Callbacks

        /// <summary>
        /// Initialize the FSM and Awake all registered states
        /// </summary>
        protected virtual void Awake()
        {
            //initialize this fsm
            Initialize();

            //Awake all states
            foreach (var state in register.Values)
                state.OnAwake();

            Log("States Awoke", "blue");
        }

        /// <summary>
        /// Start all registered states
        /// </summary>
        protected virtual void Start()
        {
            foreach (var state in register.Values)
                state.OnStart();

            Log("States Started", "blue");
        }


        /*
        /// <summary>
        /// Update all registered states (uncomment it if you need this callback).
        /// TODO: Consider to replace 'foreach' by 'for' to minimize garbage collection.
        /// </summary>
        protected virtual void Update()
        {
            var current = this.PeekState();
            if (current != null)
                current.OnUpdate();
        }
        */

        #endregion

        # region Operations
        /// <summary>
        /// Pushes a State by Type triggering OnEnterState for the pushed
        /// State and OnExitState for the previous State in the stack.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        public void PushState<T1>() where T1 : StateMB<T>
        {
            var stateType = typeof(T1);
            var state = register[stateType];
            PushState(state);
        }

        /// <summary>
        /// Pushes State by instance of the class triggering OnEnterState for the 
        /// pushed State and OnExitState for the previous State in the stack.
        /// </summary>
        /// <param name="State"></param>
        public void PushState(StateMB<T> State)
        {
            Log("Operation: Push, State: " + State.GetType(), "purple");
            if (stack.Count > 0)
            {
                var previous = stack.Peek();
                previous.OnExitState();
            }

            stack.Push(State);
            State.OnEnterState();
        }

        /// <summary>
        /// Peeks a State from the stack. A peek returns null if the stack is empty. It doesn't trigger any call.
        /// </summary>
        /// <returns></returns>
        public StateMB<T> PeekState()
        {
            StateMB<T> state = null;

            if (stack.Count > 0)
                state = stack.Peek();

            return state;
        }

        /// <summary>
        /// Pops a State from the stack. It triggers OnExitState for the 
        /// popped State and OnEnterState for the subsequent stacked State.
        /// </summary>
        public void PopState()
        {
            if (stack.Count > 0)
            {
                var state = stack.Pop();
                Log("Operation: Pop, State: " + state.GetType(), "purple");
                state.OnExitState();
            }

            if (stack.Count > 0)
            {
                var state = stack.Peek();
                state.OnEnterState();
            }
        }

        #endregion

        private void Log(string log, string colorName = "black")
        {
            if (EnableLogs)
            {
                log = string.Format("[" + GetType() + "]: <color={0}><b>" + log + "</b></color>", colorName);
                Debug.Log(log);
            }
        }
    }
}





