using System.Collections;
using System.Collections.Generic;
using SimpleTurnBasedGame;
using UnityEngine;

public class UiPreStartGameUser : UiListener, IPreGameStart
{
    private UiUserContainer UiUser;

    private void Awake()
    {
        UiUser = GetComponent<UiUserContainer>();
    }

    void IPreGameStart.OnPreGameStart(List<IPrimitivePlayer> players)
    {
        if (UiUser.IsMyTurn())
            UiUser.UiUserHudInput.Disable();
    }
}
