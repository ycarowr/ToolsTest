using System.Collections;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UserTurnState : TurnState
    {
        protected override IEnumerator TimeOut(float time = TimeOutDelay)
        {
            if (TimeOutRoutine != null)
                StopCoroutine(TimeOutRoutine);
            else
                yield return new WaitForSeconds(time + 10);

            TryPassTurn();
        }
    }
}

