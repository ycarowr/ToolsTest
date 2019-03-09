using System;
using UnityEngine;

namespace Tools.UI.Card
{
    [RequireComponent(typeof(UiCardSelector))]
    public class UiCardBender : MonoBehaviour
    {
        [SerializeField] [Tooltip("Total amount in degrees that the cards will bend.")][Range(10, 40)]
        private float totalAngleArk;

        [SerializeField] [Tooltip("Height factor between two cards")] [Range(0.1f, 0.25f)]
        private float stepHeight;

        [SerializeField] [Tooltip("Transform used as anchor to position the cards.")]
        private Transform pivot;

        [SerializeField] [Tooltip("Renderer of the card.")]
        private SpriteRenderer cardRenderer;

        private UiCardSelector CardSelector { get; set; }

        private float CardWidth { get; set; }
        private const float Spacing = -1.0f;

        private void Awake()
        {
            CardSelector = GetComponent<UiCardSelector>();
            CardSelector.OnHandChanged += Bend;
            CardWidth = cardRenderer.bounds.size.x;
        }

        private void Bend(UiCardHand[] cards)
        {
            Debug.Log("Bend");
            if (cards == null)
                throw new ArgumentException("Can't bend a card list null");

            var pivotPosition = pivot.position;
            var fullAngle = -totalAngleArk;
            var anglePerCard = fullAngle / cards.Length;
            var firstAngle = CalcFirstAngle(fullAngle);
            var handWidth = CalcHandWidth(cards.Length);

            for (var i = 0; i < cards.Length; i++)
            {
                var card = cards[i];
                
                //set card angle
                var angleTwist = firstAngle + i * anglePerCard;
                card.transform.rotation = Quaternion.Euler(0, 0, angleTwist);

                //set card position
                var yDistance = Mathf.Abs(angleTwist) * stepHeight;
                card.transform.position = new Vector2(pivotPosition.x - handWidth / 2 + CardWidth/2, pivotPosition.y - yDistance);
                
                pivotPosition.x += handWidth / cards.Length;
            }
        }

        private static float CalcFirstAngle(float fullAngle)
        {
            return -(fullAngle / 2) + (fullAngle * 0.1f);
        }

        private float CalcHandWidth(int length)
        {
            var width = length * (Spacing + CardWidth);
            return width - Spacing;
        }
    }
}