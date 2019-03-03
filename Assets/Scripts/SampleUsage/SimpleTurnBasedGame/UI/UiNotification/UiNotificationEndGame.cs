using System.Collections;
using TMPro;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiNotificationEndGame : UiNotification, IFinishGame
    {
        [SerializeField] private PlayerSeat seat;
        [SerializeField] private string text = string.Empty;
        private const float DelayToNotify = 0.75f;
        private TMP_Text Text;

        protected override void Awake()
        {
            base.Awake();
            Text = GetComponent<TMP_Text>();
        }

        void IFinishGame.OnFinishGame(IPrimitivePlayer winner)
        {
            if (winner.Seat == seat)
            {
                Text.text = text;
                StartCoroutine(Animate());
            }
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