using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools.UI.Card
{
    [RequireComponent(typeof(UiCardSelector))]
    public class UiCardDrawer : MonoBehaviour
    {
        private UiCardSelector CardSelector { get; set; }

        [SerializeField]
        [Tooltip("Prefab of the Card")]
        private UiCardHand CardPrefab;

        private void Awake()
        {
            CardSelector = GetComponent<UiCardSelector>();
        }

        
        [Button]
        public void DrawCard()
        {
            //TODO: Consider replace this Instantiate by an Object Pool Pattern
            var card = Instantiate(CardPrefab);
            CardSelector.AddCard(card);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                DrawCard();
            }   
        }
    }
}
