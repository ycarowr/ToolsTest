using SimpleTurnBasedGame;

public class UiFinishUserTurn : UiListener, IFinishPlayerTurn
{
    private UiUserContainer UiUser;

    void IFinishPlayerTurn.OnFinishPlayerTurn(IPrimitivePlayer player)
    {
        if (UiUser.IsMyTurn())
            UiUser.UiUserHudInput.Disable();
    }

    private void Awake()
    {
        UiUser = GetComponent<UiUserContainer>();
    }
}