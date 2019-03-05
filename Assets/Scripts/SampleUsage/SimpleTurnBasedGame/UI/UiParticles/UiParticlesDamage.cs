using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiParticlesDamage : UiParticles, IDoDamage
    {
        [SerializeField] private PlayerSeat seat;

        void IDoDamage.OnDamage(IAttackable source, IDamageable target, int amount)
        {
            var player = target as IPrimitivePlayer;
            if (player.Seat == seat)
                StartCoroutine(Play());
        }
    }
}