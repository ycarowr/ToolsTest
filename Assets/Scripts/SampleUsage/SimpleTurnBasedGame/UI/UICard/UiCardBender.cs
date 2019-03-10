using System;
using UnityEngine;

namespace Tools.UI.Card
{
    // Nice configs to start are:
    // spacing = -2
    // CardWidth = 6
    // pivot pos = (0, -10, 0)
    // percTwistedAngleAddYPos = 0.12
    // TotalAngleArk = 20

    /// <summary>
    /// Class responsible to bend the cards in the player hand.
    /// </summary>
    [RequireComponent(typeof(UiCardSelector))]
    public class UiCardBender : MonoBehaviour
    {
        [SerializeField] [Tooltip("Amount of space between the cards on the X axis")][Range(0f, -5f)]
        private float spacing;

        [SerializeField] [Tooltip("Transform used as anchor to position the cards.")]
        private Transform pivot;

        [SerializeField] [Tooltip("Height factor between two cards.")] [Range(0f, 1f)]
        private float percTwistedAngleAddYPos;

        [SerializeField] [Tooltip("Total angle in degrees the cards will bend.")] [Range(0, 40)]
        private float totalAngleArk;

        [SerializeField]
        [Tooltip("Renderer of the card.")]
        private SpriteRenderer cardRenderer;
        private float CardWidth => cardRenderer.bounds.size.x;

        private UiCardSelector CardSelector { get; set; }

        private void Awake()
        {
            CardSelector = GetComponent<UiCardSelector>();
            CardSelector.OnHandChanged += Bend;
        }

        private void Bend(UiCardHand[] cards)
        {
            Debug.Log("Bend");
            if (cards == null)
                throw new ArgumentException("Can't bend a card list null");

            var fullAngle = -totalAngleArk;
            var anglePerCard = fullAngle / cards.Length;
            var firstAngle = CalcFirstAngle(fullAngle);
            var handWidth = CalcHandWidth(cards.Length);

            //calc first position of the offset on X axis
            var offsetX = pivot.position.x - handWidth/2;

            for (var i = 0; i < cards.Length; i++)
            {
                var card = cards[i];

                //set card Z angle
                var angleTwist = firstAngle + i * anglePerCard;
                card.transform.rotation = Quaternion.Euler(0, 0, angleTwist);

                //calc x position
                var xPos = offsetX + CardWidth / 2;

                //calc y position
                var yDistance = Mathf.Abs(angleTwist) * percTwistedAngleAddYPos;
                var yPos = pivot.position.y - yDistance;

                //set position
                card.transform.position = new Vector3(xPos, yPos, card.transform.position.z);

                //increment offset
                offsetX += (CardWidth + spacing);
            }
        }

        /// <summary>
        /// Calculus of the angle of the first card.
        /// </summary>
        /// <param name="fullAngle"></param>
        /// <returns></returns>
        private static float CalcFirstAngle(float fullAngle)
        {
            var magicMathFactor = 0.1f;
            return -(fullAngle / 2) + fullAngle * magicMathFactor;
        }

        /// <summary>
        /// Calculus of the width of the player's hand.
        /// </summary>
        /// <param name="quantityOfCards"></param>
        /// <returns></returns>
        private float CalcHandWidth(int quantityOfCards)
        {
            var widthCards = quantityOfCards * CardWidth;
            var widthSpacing = (quantityOfCards - 1) * spacing;
            return widthCards + widthSpacing;
        }
    }
}