namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     This interface enforces the client to return a UiUserContainer
    /// </summary>
    public interface IUiUserContainerHandler
    {
        UiUserContainer Container { get; }
    }
}