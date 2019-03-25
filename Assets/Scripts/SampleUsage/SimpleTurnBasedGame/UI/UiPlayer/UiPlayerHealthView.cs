using System.Collections.Generic;
using SimpleTurnBasedGame.ControllerCs;

namespace SimpleTurnBasedGame
{
    public class UiPlayerHealthView : UiListener, 
        IPreGameStart,
        IDoDamage,
        IDoHeal
    {
        private string HealthText { get; set; }
        private UiText UiText { get; set; }
        private IUiPlayer Ui { get; set; }

        //----------------------------------------------------------------------------------------------------------

        #region Game Events 

        void IDoDamage.OnDamage(IAttackable source, IDamageable target, int amount)
        {
            SetHealth();
        }

        void IDoHeal.OnHeal(IHealer source, IHealable target, int amount)
        {
            SetHealth();
        }

        void IPreGameStart.OnPreGameStart(List<IPrimitivePlayer> players)
        {
            SetHealth();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        private void Awake()
        {
            Ui = GetComponentInParent<IUiPlayer>();
            UiText = GetComponent<UiText>();
            HealthText = Localization.Instance.Get(LocalizationIds.Health);
        }

        private void SetHealth()
        {
            var health = Ui.PlayerController.Player.Health;
            UiText.SetText(HealthText + ": " + health);
        }
    }
}