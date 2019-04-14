﻿using System.Runtime.CompilerServices;
using Patterns.StateMachine;
using UnityEngine;

namespace Tools.UI.Card
{
    //--------------------------------------------------------------------------------------------------------------
    
    #region Interface
    
    //TODO: Consider to split this gigantic interface in smaller ones. SOL(I)D.
    public interface IUiCard : IStateMachineHandler
    {
        UiCardParameters CardConfigsParameters { get; }
        Camera MainCamera { get; }
        IUiCardSelector CardSelector { get; }
        SpriteRenderer[] Renderers { get; }
        SpriteRenderer MyRenderer { get; }
        Collider Collider { get; }
        Rigidbody Rigidbody { get; }
        Transform Transform { get; }
        IMouseInput Input { get; }
        GameObject gameObject { get; }
        Transform transform { get; }
        UiCardMovement  UiCardMovement { get; }
        MonoBehaviour MonoBehavior { get; }
        

        bool IsDragging { get; }
        bool IsHovering { get; }

        //cards operations
        void Play();
        void Disable();
        void Enable();
        void Select();
        void Unselect();
        void Hover();
        void MoveTo(Vector3 position);
        void RotateTo(Vector3 euler);
    }
    
    #endregion
    
    //--------------------------------------------------------------------------------------------------------------

    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(IMouseInput))]
    public class UiCardHandSystem : MonoBehaviour, IUiCard
    {
        //--------------------------------------------------------------------------------------------------------------
        
        #region Properties

        private UiCardHandFsm CardHandFsm { get; set; }
        private Transform MyTransform { get; set; }
        private Collider MyCollider { get; set; }
        private SpriteRenderer[] MyRenderers { get; set; }
        private SpriteRenderer MyRenderer { get; set; }
        private Rigidbody MyRigidbody { get; set; }
        private IMouseInput MyInput { get; set; }
        private IUiCardSelector MyCardSelector { get; set; }
        public MonoBehaviour MonoBehavior => this;
        public Camera MainCamera => Camera.main;

        [SerializeField] public UiCardParameters cardConfigsParameters;
        public UiCardParameters CardConfigsParameters => cardConfigsParameters;

        SpriteRenderer[] IUiCard.Renderers => MyRenderers;
        SpriteRenderer IUiCard.MyRenderer => MyRenderer;
        Collider IUiCard.Collider => MyCollider;
        Rigidbody IUiCard.Rigidbody => MyRigidbody;
        Transform IUiCard.Transform => MyTransform;
        IMouseInput IUiCard.Input => MyInput;
        IUiCardSelector IUiCard.CardSelector => MyCardSelector;
        public bool IsDragging => CardHandFsm.IsCurrent<UiCardDrag>();
        public bool IsHovering => CardHandFsm.IsCurrent<UiCardHover>();
        
        public UiCardMovement UiCardMovement { get; private set; }
        public UiCardRotation UiCardRotation { get; private set; }

        #endregion
        
        //--------------------------------------------------------------------------------------------------------------

        #region Operations

        public void RotateTo(Vector3 rotation)
        {
            UiCardRotation.RotateTo(rotation);
        }

        public void MoveTo(Vector3 position)
        {
            UiCardMovement.MoveTo(position);
        }

        public void Hover()
        {
            CardHandFsm.Hover();
        }

        public void Disable()
        {
            CardHandFsm.Disable();
        }

        public void Enable()
        {
            CardHandFsm.Enable();
        }

        public void Play()
        {
            MyCardSelector.PlayCard(this);
        }

        public void Select()
        {
            MyCardSelector.SelectCard(this);
            CardHandFsm.Select();
        }

        public void Unselect()
        {
            CardHandFsm.Unselect();
            MyCardSelector.UnselectCard(this);
        }

        #endregion
        
        //--------------------------------------------------------------------------------------------------------------

        #region Unity Callbacks

        private void Awake()
        {
            MyTransform = transform;
            MyCollider = GetComponent<Collider>();
            MyRigidbody = GetComponent<Rigidbody>();
            MyInput = GetComponent<IMouseInput>();
            MyCardSelector = GetComponentInParent<IUiCardSelector>();
            MyRenderers = GetComponentsInChildren<SpriteRenderer>();
            MyRenderer = GetComponent<SpriteRenderer>();
            UiCardMovement = new UiCardMovement(this, cardConfigsParameters);
            UiCardRotation = new UiCardRotation(this, cardConfigsParameters);
            CardHandFsm = new UiCardHandFsm(MainCamera, CardConfigsParameters, this);
        }

        private void Update()
        {
            CardHandFsm.Update();
            UiCardMovement.Update();
            UiCardRotation.Update();
        }

        #endregion
        
        //--------------------------------------------------------------------------------------------------------------
    }
}