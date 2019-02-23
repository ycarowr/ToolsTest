namespace SimpleTurnBasedGame
{
    public class UiPlayerNameView: UiTextMeshProText, IUiPlayerUpdateView
    {
        //TODO: Replace "string.Format(...)" calls by StringBuilder.Append(..)
        public void UpdatePlayer(IPrimitivePlayer player)
        {
            var playerText = Localization.Instance.Get(LocalizationIds.Player);
            SetText(playerText + player.Seat);
        }
    }
}