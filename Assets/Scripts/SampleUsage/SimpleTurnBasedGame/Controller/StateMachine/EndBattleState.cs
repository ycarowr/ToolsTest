using System.Collections;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    /// <summary>
    /// Holds the Gameflow when a match is Finished.
    /// </summary>
    public class EndBattleState : BaseBattleState, IFinishGame
    {
        void IFinishGame.OnFinishGame(IPrimitivePlayer winner)
        {
            Fsm.EndBattle();            
        }
    }
}