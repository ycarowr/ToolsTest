using System.Collections;
using System.Collections.Generic;
using Patterns;
using UnityEngine;

namespace Tools.UI.Card
{
    /// <summary>
    /// Base UI Card State.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(IMouseInput))]
    [RequireComponent(typeof(SpriteRenderer))]
    public abstract class UiBaseCardState : StateMB<UiCardHand>
    {
        protected const int LayerToRenderNormal = 0;
        protected const int LayerToRenderFirst = 1;
        protected SpriteRenderer[] MyRenderers { get; set; }
        protected Collider MyCollider { get; set; }
        protected Rigidbody MyRigidbody { get; set; }
        protected Transform MyTransform { get; set; }
        protected IMouseInput MyInput { get; set; }

        public override void OnAwake()
        {
            MyRenderers = GetComponentsInChildren<SpriteRenderer>();
            MyCollider = GetComponent<Collider>();
            MyRigidbody = GetComponent<Rigidbody>();
            MyTransform = GetComponent<Transform>();
            MyInput = GetComponent<IMouseInput>();
        }

        public virtual void MakeRenderFirst()
        {
            for (var i = 0; i < MyRenderers.Length; i++)
                MyRenderers[i].sortingOrder = 1;
        }

        public virtual void MakeRenderNormal()
        {
            for (var i = 0; i < MyRenderers.Length; i++)
                MyRenderers[i].sortingOrder = 0;
        }
    }
}