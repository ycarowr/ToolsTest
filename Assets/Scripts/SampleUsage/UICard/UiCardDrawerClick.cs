using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tools.UI.Card
{
    [RequireComponent(typeof(IMouseInput))]
    public class UiCardDrawerClick : MonoBehaviour
    {
        private UiCardDrawer CardDrawer { get; set; }
        private IMouseInput Input { get; set; }
        private void Awake()
        {
            CardDrawer = GetComponentInParent<UiCardDrawer>();
            Input = GetComponent<IMouseInput>();
            Input.OnPointerClick += DrawCard;
        }

        private void DrawCard(PointerEventData obj)
        {
            CardDrawer.DrawCard(0);
        }
    }
}