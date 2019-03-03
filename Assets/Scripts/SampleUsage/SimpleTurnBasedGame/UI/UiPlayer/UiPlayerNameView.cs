using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiPlayerNameView : MonoBehaviour
    {
        private string playerText;
        private UiPlayerContainer UiParent;
        private UiText UiText;

        private void Awake()
        {
            UiParent = GetComponentInParent<UiPlayerContainer>();
            UiText = GetComponent<UiText>();
            playerText = Localization.Instance.Get(LocalizationIds.Player);
        }

        private void Start()
        {
            UiText.SetText(playerText + ": " + UiParent.Seat);
        }
    }
}