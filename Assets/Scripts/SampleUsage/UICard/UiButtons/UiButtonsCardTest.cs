﻿using UnityEngine;
using UnityEngine.Assertions;

namespace Tools.UI.Card
{
    public class UiButtonsCardTest : MonoBehaviour
    {
        [SerializeField] protected UiCardSelector CardSelector;

        protected virtual void Awake()
        {
            Assert.IsNotNull(CardSelector);

            CardSelector.OnHandChanged += CardSelector_OnHandChanged;
        }

        protected virtual void CardSelector_OnHandChanged(IUiCard[] cards)
        {
        }
    }
}