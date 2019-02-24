using System.Collections;
using System.Collections.Generic;
using SimpleTurnBasedGame;
using UnityEngine;

public class UiFinishUserTurn : UiListener, IFinishPlayerTurn
{
    private UiPlayerUserContainer UiUser;

    private void Awake()
    {
        UiUser = GetComponent<UiPlayerUserContainer>();
    }

    void IFinishPlayerTurn.OnFinishPlayerTurn(IPrimitivePlayer player)
    {
        if (UiUser.IsMyTurn())
            UiUser.UiPlayerUserInput.DisableInput();
    }
}
