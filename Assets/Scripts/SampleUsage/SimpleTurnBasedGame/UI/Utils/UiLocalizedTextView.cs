using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiLocalizedTextView : UiTextMeshProText
    {
        [SerializeField] private LocalizationIds id;

        public virtual void SetText(LocalizationIds id)
        {
            SetText(Localization.Instance.Get(id));
        }

        //TODO: Replace "string.Format(...)" calls by StringBuilder.Append(..)
        public virtual void AddText(LocalizationIds id, string inBetween = "")
        {
            var current = TmProText.text;
            var next = Localization.Instance.Get(id);
            SetText(string.Format(current, inBetween, next));
        }
    }
}
