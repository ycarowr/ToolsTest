using System;
using System.Collections.Generic;
using Tools.UI.Card;
using UnityEngine;

namespace Patterns.StateMachine
{

    #region Interfaces
    
    public interface IStateMachineHandler
    {

    }
   
    public interface IStateMachine
    {
        IStateMachineHandler Handler { get; }
        bool IsCurrent<T>() where T : IState;
        bool IsCurrent(IState state);
        void PushState<T>(bool isSilent = false) where T : IState;
    }

    public interface IState
    {
        IStateMachine Fsm { get; set; }
        void OnInitialize();
        void OnEnterState();
        void OnExitState();
        void OnUpdate();
    }

    #endregion

    public abstract class StateMachine : IStateMachine
    {
        public bool IsInitialized { get; protected set; }

        //Push-Pop stack of States of this Type of Finite state Machine
        private readonly Stack<IState> stack = new Stack<IState>();
        
        //This register doesn't allow you to have two states with the same Type
        private readonly Dictionary<Type, IState> statesRegister = new Dictionary<Type, IState>();
        
        public IStateMachineHandler Handler { get; }
        public bool EnableLogs = true;


        /// <summary>
        /// Constructor for the state machine. A handler is optional.
        /// <param name="handler"></param>
        protected StateMachine(IStateMachineHandler handler = null)
        {
            Handler = handler;
        }

        /// <summary>
        /// Register a state into the state machine.
        /// </summary>
        /// <param name="state"></param>
        public void RegisterState(IState state)
        {
            var type = state.GetType();
            statesRegister.Add(type, state);
        }

        /// <summary>
        ///     Initialize states
        /// </summary>
        public void Initialize()
        {
            OnBeforeInitialize();

            //register all states
            foreach (var state in statesRegister.Values)
            {
                state.Fsm = this;
                state.OnInitialize();
            }

            IsInitialized = true;

            OnInitialize();

            Log("Initialized!", "green");
        }

        /// <summary>
        ///     If you need to do something before the initialization, override this method.
        /// </summary>
        protected virtual void OnBeforeInitialize()
        {
        }

        /// <summary>
        ///     If you need to do something after the initialization, override this method.
        /// </summary>
        protected virtual void OnInitialize()
        {
        }


        //TODO: Consider to implement a Logger for this class.
        private void Log(string log, string colorName = "black")
        {
            if (EnableLogs)
            {
                log = string.Format("[" + GetType() + "]: <color={0}><b>" + log + "</b></color>", colorName);
                Debug.Log(log);
            }
        }

        # region Operations

        public void Update()
        {
            var current = PeekState();
            current?.OnUpdate();
        }

        /// <summary>
        ///     Checks if a an StateType is the current state.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public bool IsCurrent<T>() where T : IState
        {
            var current = PeekState();
            if (current == null)
                return false;

            return current.GetType() == typeof(T);
        }

        /// <summary>
        ///     Checks if a an StateType is the current state.
        /// </summary>
        public bool IsCurrent(IState state)
        {
            if (state == null)
                throw new ArgumentNullException();

            var current = PeekState();
            if (current == null)
                return false;
            return current.GetType() == state.GetType();
        }

        /// <summary>
        ///     Pushes a state by Type triggering OnEnterState for the pushed
        ///     state and OnExitState for the previous state in the stack.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void PushState<T>(bool isSilent = false) where T: IState
        {
            var stateType = typeof(T);
            var state = statesRegister[stateType];
            PushState(state, isSilent);
        }

        /// <summary>
        ///     Pushes state by instance of the class triggering OnEnterState for the
        ///     pushed state and if not silent OnExitState for the previous state in the stack.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="isSilent"></param>
        public void PushState(IState state, bool isSilent = false)
        {
            if (!statesRegister.ContainsKey(state.GetType()))
                throw new ArgumentException("State " + state + " not registered yet.");

            Log("Operation: Push, state: " + state.GetType(), "purple");
            if (stack.Count > 0 && !isSilent)
            {
                var previous = stack.Peek();
                previous.OnExitState();
            }

            stack.Push(state);
            state.OnEnterState();
        }

        /// <summary>
        ///     Peeks a state from the stack. A peek returns null if the stack is empty. It doesn't trigger any call.
        /// </summary>
        /// <returns></returns>
        public IState PeekState()
        {
            IState state = null;

            if (stack.Count > 0)
                state = stack.Peek();

            return state;
        }

        /// <summary>
        ///     Pops a state from the stack. It triggers OnExitState for the
        ///     popped state and if not silent OnEnterState for the subsequent stacked state.
        /// </summary>
        /// <param name="isSilent"></param>
        public void PopState(bool isSilent = false)
        {
            if (stack.Count > 0)
            {
                var state = stack.Pop();
                Log("Operation: Pop, state: " + state.GetType(), "purple");
                state.OnExitState();
            }

            if (stack.Count > 0 && !isSilent)
            {
                var state = stack.Peek();
                state.OnEnterState();
            }
        }

        #endregion
    }
}