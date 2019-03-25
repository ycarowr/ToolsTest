using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiTextButtonDamage : UiText
    {
        [SerializeField] private Configurations configurations;

        private int MaxDamage => configurations.Damage.MaxDamage;
        private int MinDamage => configurations.Damage.MinDamage;

        protected override void Awake()
        {
            base.Awake();
            var damageText = Localization.Instance.Get(LocalizationIds.Damage);
            var moveText = Localization.Instance.Get(LocalizationIds.Move);

            SetText($"[{MinDamage}-{MaxDamage - 1}] {damageText} {moveText}");
        }
    }
}