using System.Collections;
using SimpleTurnBasedGame;
using UnityEngine;

public class UiStartUserTurn : UiListener, IStartPlayerTurn
{
    private const float DelayToEnableInput = 2;
    private UiUserContainer UiUser;

    void IStartPlayerTurn.OnStartPlayerTurn(IPrimitivePlayer player)
    {
        if (UiUser.IsMyTurn() && !UiUser.IsAi())
            StartCoroutine(EnableInput());
    }

    private void Awake()
    {
        UiUser = GetComponent<UiUserContainer>();
    }


    private IEnumerator EnableInput()
    {
        yield return new WaitForSeconds(DelayToEnableInput);
        UiUser.UiUserHudInput.Enable();
    }

}