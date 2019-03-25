﻿using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiTextButtonHeal : UiText
    {
        [SerializeField] private Configurations configurations;

        private int MaxHeal=> configurations.Heal.MaxHeal;
        private int MinHeal => configurations.Heal.MinHeal;

        protected override void Awake()
        {
            base.Awake();
            var healText = Localization.Instance.Get(LocalizationIds.Heal);
            var moveText = Localization.Instance.Get(LocalizationIds.Move);

            SetText($"[{MinHeal}-{MaxHeal - 1}] {healText} {moveText}");
        }
    }
}