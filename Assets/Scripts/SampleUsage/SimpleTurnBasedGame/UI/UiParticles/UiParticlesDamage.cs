using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiParticlesDamage : UiParticles, IDoDamage
    {
        private IUiPlayer Ui { get; set; }

        protected override void Awake()
        {
            base.Awake();
            Ui = GetComponentInParent<IUiPlayer>();
        }

        void IDoDamage.OnDamage(IAttackable source, IDamageable target, int amount)
        {
            var player = target as IPrimitivePlayer;
            if (player.Seat == Ui.Seat)
                StartCoroutine(Play());
        }
    }
}