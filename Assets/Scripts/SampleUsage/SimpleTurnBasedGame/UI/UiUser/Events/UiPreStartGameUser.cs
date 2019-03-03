using System.Collections.Generic;
using SimpleTurnBasedGame;

public class UiPreStartGameUser : UiListener, IPreGameStart
{
    private UiUserContainer UiUser;

    void IPreGameStart.OnPreGameStart(List<IPrimitivePlayer> players)
    {
        if (UiUser.IsMyTurn())
            UiUser.UiUserHudInput.Disable();
    }

    private void Awake()
    {
        UiUser = GetComponent<UiUserContainer>();
    }
}