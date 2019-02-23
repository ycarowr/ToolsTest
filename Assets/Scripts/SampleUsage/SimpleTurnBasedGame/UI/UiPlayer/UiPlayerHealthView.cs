using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiPlayerHealthView: UiTextMeshProText, IUiPlayerUpdateView
    {
        //TODO: Replace "string.Format(...)" calls by StringBuilder.Append(..)
        public void UpdatePlayer(IPrimitivePlayer player)
        {
            Debug.Log(player.Seat);
            var healthText = Localization.Instance.Get(LocalizationIds.Health);
            SetText(healthText + ": " + player.Health);
        }
    }
}