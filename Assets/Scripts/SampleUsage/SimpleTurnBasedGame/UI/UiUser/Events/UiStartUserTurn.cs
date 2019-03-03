using System.Collections;
using System.Collections.Generic;
using SimpleTurnBasedGame;
using UnityEngine;

public class UiStartUserTurn : UiListener, IStartPlayerTurn
{
    private UiUserContainer UiUser;

    private void Awake()
    {
        UiUser = GetComponent<UiUserContainer>();
    }

    void IStartPlayerTurn.OnStartPlayerTurn(IPrimitivePlayer player)
    {
        if (UiUser.IsMyTurn() && !UiUser.IsAi())
            UiUser.UiUserHudInput.Enable();
    }
}
