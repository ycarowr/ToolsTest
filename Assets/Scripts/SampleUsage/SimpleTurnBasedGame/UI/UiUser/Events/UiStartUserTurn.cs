using SimpleTurnBasedGame;

public class UiStartUserTurn : UiListener, IStartPlayerTurn
{
    private UiUserContainer UiUser;

    void IStartPlayerTurn.OnStartPlayerTurn(IPrimitivePlayer player)
    {
        if (UiUser.IsMyTurn() && !UiUser.IsAi())
            UiUser.UiUserHudInput.Enable();
    }

    private void Awake()
    {
        UiUser = GetComponent<UiUserContainer>();
    }
}