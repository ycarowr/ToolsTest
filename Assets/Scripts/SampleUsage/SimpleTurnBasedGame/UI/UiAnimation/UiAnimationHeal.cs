using TMPro;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiAnimationHeal : UiAnimation, IDoHeal
    {
        private TMP_Text Text { get; set; }
        
        protected override void Awake()
        {
            base.Awake();
            Text = GetComponent<TMP_Text>();
        }

        void IDoHeal.OnHeal(IHealer source, IHealable target, int amount)
        {
            Text.text = Localization.Instance.Get(LocalizationIds.Heal) + "+"+amount;
            StartCoroutine(Animate());
        }
    }
}