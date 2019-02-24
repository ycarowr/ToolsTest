using System.Collections;
using TMPro;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiNotificationStartGame : UiNotification, IStartGame
    {
        private const float DelayToNotify = 0.75f;
        private TMP_Text Text;

        protected override void Awake()
        {
            base.Awake();
            Text = GetComponent<TMP_Text>();
        }

        void IStartGame.OnStartGame(IPrimitivePlayer player)
        {
            Text.text = player.Seat +" player starts!";

            StartCoroutine(Animate());
        }

        private IEnumerator Animate()
        {
            yield return new WaitForSeconds(DelayToNotify);
            foreach (var p in Particles)
                p.Play();

            Animator.Play(hashName);
        }
    }
}