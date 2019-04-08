using System;
using Patterns.StateMachine;
using UnityEngine;

namespace Tools.UI.Card
{
    public class UiCardMovement
    {
        public Action OnArrive = () => { };
        
        private const float Threshold = 0.01f;
        private Vector3 Target { get; set; }
        private float Speed { get; }
        private IUiCard Handler { get; }
        private UiCardParameters Parameters { get; }
        public bool IsMoving { get; private set; }

        //--------------------------------------------------------------------------------------------------------------
        
        public UiCardMovement(IUiCard handler, UiCardParameters parameters)
        {
            Handler = handler;
            Parameters = parameters;
            Speed = 6;
        }
        
        
        //--------------------------------------------------------------------------------------------------------------
        
        #region Operations

        public void Update()
        {
            if (!IsMoving)
                return;
            
            var distance = Target - Handler.transform.position;
            if (distance.magnitude > Threshold)
                KeepMoving();
            else
                ToArrive();
        }
        
        #endregion
        
        //--------------------------------------------------------------------------------------------------------------
        
        private void ToArrive()
        {
            Handler.transform.position = Target;
            IsMoving = false;
            OnArrive?.Invoke();
        }

        private void KeepMoving()
        {
            var current = Handler.transform.position;
            Handler.transform.position = Vector3.Lerp(current, Target, Speed * Time.deltaTime);
        }
        
        public void MoveTo(Vector3 position)
        {
            IsMoving = true;
            Target = position;
        }
    }
}