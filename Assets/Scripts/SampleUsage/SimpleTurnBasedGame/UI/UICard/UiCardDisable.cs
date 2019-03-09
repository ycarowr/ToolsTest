using System.Collections;
using System.Collections.Generic;
using Patterns;
using UnityEngine;

namespace Tools.UI.Card
{
    /// <summary>
    /// This state disables the collider of the card.
    /// </summary>
    public class UiCardDisable : UiBaseCardState
    {
        public override void OnEnterState()
        {
            Disable();
        }

        private void Disable()
        {
            MyCollider.enabled = false;
            MyRigidbody.Sleep();
            MakeRenderNormal();
        }
    }
}