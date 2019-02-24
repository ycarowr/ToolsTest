using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiNotificationTurn : UiNotification, IStartPlayerTurn
    {
        [SerializeField] private PlayerSeat seat;

        void IStartPlayerTurn.OnStartPlayerTurn(IPrimitivePlayer player)
        {
            if (player.Seat == seat)
                Animate();
        }

        private void Animate()
        {
            foreach (var p in Particles)
                p.Play();

            Animator.Play(hashName);
        }
    }
}