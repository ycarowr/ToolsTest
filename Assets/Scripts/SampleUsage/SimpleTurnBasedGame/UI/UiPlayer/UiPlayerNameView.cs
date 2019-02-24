using System.Collections.Generic;
using Patterns;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiPlayerNameView : MonoBehaviour
    {
        private UiPlayerContainer UiParent;
        private UiText UiText;
        private string playerText;

        private void Awake()
        {
            UiParent = GetComponentInParent<UiPlayerContainer>();
            UiText = GetComponent<UiText>();
            playerText = Localization.Instance.Get(LocalizationIds.Player);
        }

        private void Start()
        {
            UiText.SetText(playerText +": "+UiParent.Seat);
        }
    }
}