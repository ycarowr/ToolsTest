using System.Collections.Generic;

namespace SimpleTurnBasedGame
{
    //TODO: Replace "string.Format(...)" calls by StringBuilder.Append(..)
    public class UiPlayerHealthView : UiListener,
        IPreGameStart,
        IDoDamage,
        IDoHeal
    {
        private string healthText;
        private UiPlayerContainer UiParent;
        private UiText UiText;

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

        private void Awake()
        {
            UiParent = GetComponentInParent<UiPlayerContainer>();
            UiText = GetComponent<UiText>();
            healthText = Localization.Instance.Get(LocalizationIds.Health);
        }

        private void UpdateText()
        {
            var health = UiParent.GetPlayer().Player.Health;
            UiText.SetText(healthText + ": " + health);
        }
    }
}