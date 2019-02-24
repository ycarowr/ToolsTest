﻿using System.Collections;
using System.Collections.Generic;
using SimpleTurnBasedGame;
using UnityEngine;

public class UiStartUserTurn : UiListener, IStartPlayerTurn
{
    private UiPlayerUserContainer UiUser;

    private void Awake()
    {
        UiUser = GetComponent<UiPlayerUserContainer>();
    }

    void IStartPlayerTurn.OnStartPlayerTurn(IPrimitivePlayer player)
    {
        if (UiUser.IsMyTurn())
        {
            UiUser.UiPlayerUserInput.EnableInput();
        }
    }
}