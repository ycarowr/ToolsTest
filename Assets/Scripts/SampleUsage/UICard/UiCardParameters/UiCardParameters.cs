using UnityEngine;

namespace Tools.UI.Card
{
    [CreateAssetMenu(menuName = "Card Config Parameters")]
    public class UiCardParameters : ScriptableObject
    {
        #region Disable

        [Header("Disable")] [Tooltip("How a card fades when disabled.")] [SerializeField] [Range(0.1f, 1)]
        private float disabledAlpha;

        public float DisabledAlpha
        {
            get => disabledAlpha;
            set => disabledAlpha = value;
        }

        #endregion

        #region Hover

        [Header("Hover")] [SerializeField] [Tooltip("How much the card will go upwards when hovered.")] [Range(0, 2)]
        private float hoverHeight;

        public float HoverHeight
        {
            get => hoverHeight;
            set => hoverHeight = value;
        }

        [SerializeField] [Tooltip("Whether the hovered card keep its rotation.")]
        private bool hoverRotation;

        public bool HoverRotation
        {
            get => hoverRotation;
            set => hoverRotation = value;
        }

        [SerializeField] [Tooltip("How much a hovered card scales.")] [Range(0.9f, 2f)]
        private float hoverScale;

        public float HoverScale
        {
            get => hoverScale;
            set => hoverScale = value;
        }

        #endregion

        #region Bend

        [Header("Bend")] [SerializeField] [Tooltip("Height factor between two cards.")] [Range(0f, 1f)]
        private float height;

        public float Height
        {
            get => height;
            set => height = value;
        }

        [SerializeField] [Tooltip("Amount of space between the cards on the X axis")] [Range(0f, -5f)]
        private float spacing;

        public float Spacing
        {
            get => spacing;
            set => spacing = -value;
        }

        [SerializeField] [Tooltip("Total angle in degrees the cards will bend.")] [Range(0, 60)]
        private float bentAngle;

        public float BentAngle
        {
            get => bentAngle;
            set => bentAngle = value;
        }

        #endregion
    }
}