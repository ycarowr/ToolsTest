﻿using System;
using Extensions;
using Patterns.StateMachine;
using UnityEngine;

namespace Tools.UI.Card
{
    public class UiCardDrag : UiBaseCardState
    {
        //--------------------------------------------------------------------------------------------------------------
        
        public UiCardDrag(IUiCard handler, Camera camera, BaseStateMachine fsm, UiCardParameters parameters) : base(handler, fsm, parameters)
        {
            MyCamera = camera;
        }

        private Vector3 StartPosition { get; set; }
        private Quaternion StartRotation { get; set; }
        private Camera MyCamera { get; }
        
        //--------------------------------------------------------------------------------------------------------------
        
        #region Operations

        public override void OnUpdate()
        {
            AddMovement();
        }

        public override void OnEnterState()
        {
            //cache old values
            StartPosition = Handler.Transform.position;
            StartRotation = Handler.Transform.rotation;

            Handler.Transform.localRotation = Quaternion.identity;
            MakeRenderFirst();
            NormalColor();
        }

        public override void OnExitState()
        {
            //reset position and rotation
            Handler.Transform.position = StartPosition;
            Handler.Transform.rotation = StartRotation;
            MakeRenderNormal();
        }
        
        #endregion
        
        //--------------------------------------------------------------------------------------------------------------
        

        private Vector3 WorldPoint()
        {
            var mousePosition = Handler.Input.MousePosition;
            var worldPoint = MyCamera.ScreenToWorldPoint(mousePosition);
            return worldPoint;
        }

        private void AddMovement()
        {
            var myZ = Handler.Transform.position.z;
            Handler.Transform.position = WorldPoint().WithZ(myZ);
        }

        private void AddTorque()
        {
            //TODO: Add Torque to the Card.

            throw new NotImplementedException();
        }
        
        //--------------------------------------------------------------------------------------------------------------
        
    }
}