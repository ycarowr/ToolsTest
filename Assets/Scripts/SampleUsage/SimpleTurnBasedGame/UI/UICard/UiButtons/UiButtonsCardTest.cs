<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using Tools.UI.Card;
using UnityEngine;
using UnityEngine.Assertions;


=======
﻿using UnityEngine;
using UnityEngine.Assertions;

>>>>>>> Add Test Scene for Card Hand UI
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
<<<<<<< HEAD
        
        protected virtual void CardSelector_OnHandChanged(UiCardHand[] cards)
        {
            
        }
    }
}
=======

        protected virtual void CardSelector_OnHandChanged(UiCardHand[] cards)
        {
        }
    }
}
>>>>>>> Add Test Scene for Card Hand UI
