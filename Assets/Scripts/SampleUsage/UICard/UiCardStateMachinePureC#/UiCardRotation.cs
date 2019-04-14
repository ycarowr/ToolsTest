using System;
using Patterns.StateMachine;
using UnityEngine;

namespace Tools.UI.Card
{
    public class UiCardRotation
    {
        public Action OnArrive = () => { };
        
        private const float Threshold = 0.1f;
        private Vector3 TargetEuler { get; set; }
        private float Speed { get; set; }
        private IUiCard Handler { get; }
        private UiCardParameters Parameters { get; }
        public bool IsRotating { get; private set; }

        //--------------------------------------------------------------------------------------------------------------
        
        public UiCardRotation(IUiCard handler, UiCardParameters parameters)
        {
            Handler = handler;
            Parameters = parameters;
        }
        
        
        //--------------------------------------------------------------------------------------------------------------
        
        #region Operations

        public void Update()
        {
            if (!IsRotating)
                return;
            
            var distance = TargetEuler- Handler.transform.eulerAngles;
            
            if (distance.magnitude <= Threshold || (int) distance.magnitude == 360)
                ToArrive();
            else
                KeepMoving();
        }
        
        #endregion
        
        //--------------------------------------------------------------------------------------------------------------
        
        private void ToArrive()
        {
            Handler.transform.eulerAngles = TargetEuler;
            IsRotating = false;
            OnArrive?.Invoke();
        }

        private void KeepMoving()
        {
            var current = Handler.transform.rotation;
            Handler.transform.rotation = Quaternion.RotateTowards(current, Quaternion.Euler(TargetEuler), Parameters.RotationSpeed * Time.deltaTime);
        }
        
        public void RotateTo(Vector3 euler)
        {
            IsRotating = true;
            TargetEuler = euler;
        }
    }
}