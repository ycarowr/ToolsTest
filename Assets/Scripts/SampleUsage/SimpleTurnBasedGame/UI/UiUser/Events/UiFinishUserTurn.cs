﻿using System.Collections;
using System.Collections.Generic;
using SimpleTurnBasedGame;
using UnityEngine;

public class UiFinishUserTurn : UiListener, IFinishPlayerTurn
{
    private UiUserContainer UiUser;

    private void Awake()
    {
        UiUser = GetComponent<UiUserContainer>();
    }

    void IFinishPlayerTurn.OnFinishPlayerTurn(IPrimitivePlayer player)
    {
        if (UiUser.IsMyTurn())
            UiUser.UiUserHudInput.Disable();
    }
}
