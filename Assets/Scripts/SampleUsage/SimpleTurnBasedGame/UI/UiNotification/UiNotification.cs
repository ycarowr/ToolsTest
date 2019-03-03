using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiNotification : UiListener
    {
        protected readonly int hashName = Animator.StringToHash("Notification");
        protected Animator Animator;
        protected ParticleSystem[] Particles;

        protected virtual void Awake()
        {
            Animator = GetComponent<Animator>();
            Particles = GetComponentsInChildren<ParticleSystem>();
        }
    }
}