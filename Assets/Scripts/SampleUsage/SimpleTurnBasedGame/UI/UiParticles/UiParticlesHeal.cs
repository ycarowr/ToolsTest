using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiParticlesHeal : UiParticles, IDoHeal
    {
        [SerializeField] private PlayerSeat seat;

        void IDoHeal.OnHeal(IHealer source, IHealable target, int amount)
        {
            var player = target as IPrimitivePlayer;
            if (player.Seat == seat)
                StartCoroutine(Play());
        }
    }
}