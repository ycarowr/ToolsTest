using Extensions;
using UnityEngine;

namespace Tools.UI.Card
{
    [RequireComponent(typeof(UiCardSelector))]
    public class UiCardDrawer : MonoBehaviour
    {
        [SerializeField] [Tooltip("Prefab of the Card")]
        private UiCardHand CardPrefab;

        private UiCardSelector CardSelector { get; set; }

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

        [Button]
        public void PlayCard()
        {
            if (CardSelector.Cards.Count > 0)
            {
                var randomCard = CardSelector.Cards.RandomItem();
                CardSelector.PlayCard(randomCard);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.D)) DrawCard();
            if (Input.GetKeyDown(KeyCode.Space)) PlayCard();
        }
    }
}