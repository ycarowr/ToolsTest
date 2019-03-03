using System.Collections;
using TMPro;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiAnimationEndGame : UiAnimation, IFinishGame
    {
        private const float DelayToNotify = 1f;
        [SerializeField] private PlayerSeat seat;
        [SerializeField] private LocalizationIds id;
        private TMP_Text Text;

        void IFinishGame.OnFinishGame(IPrimitivePlayer winner)
        {
            if (winner.Seat == seat)
            {
                Text.text = Localization.Instance.Get(id);
                StartCoroutine(Animate(DelayToNotify));
            }
        }

        protected override void Awake()
        {
            base.Awake();
            Text = GetComponent<TMP_Text>();
        }
    }
}