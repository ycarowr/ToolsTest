using System.Collections.Generic;
using Patterns;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    //TODO: Replace "string.Format(...)" calls by StringBuilder.Append(..)
    public class UiPlayerHealthView: UiListener,
        IPreGameStart, 
        IDoDamage, 
        IDoHeal
    {
        private UiPlayerContainer UiParent;
        private UiText UiText;
        private string healthText;
        
        private void Awake()
        {
            UiParent = GetComponentInParent<UiPlayerContainer>();
            UiText = GetComponent<UiText>();
            healthText = Localization.Instance.Get(LocalizationIds.Health);
        }

        void IDoDamage.OnDamage(IAttackable source, IDamageable target, int amount)
        {
            UpdateText();
        }

        void IDoHeal.OnHeal(IHealer source, IHealable target, int amount)
        {
            UpdateText();
        }

        void IPreGameStart.OnPreGameStart(List<IPrimitivePlayer> players)
        {
            UpdateText();
        }

        private void UpdateText()
        {
            var health = UiParent.GetPlayer().Player.Health;
            UiText.SetText(healthText + ": " + health);
        }
    }
}