using System.Collections;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class StartBattleState : BaseBattleState, IStartGame
    {
        private const float TimeUntilFirstTurn = 3;

        #region Model --> Controller

        void IStartGame.OnStartGame(IPrimitivePlayer starter)
        {
            var nextTurn = Fsm.GetPlayer(starter);
            StartCoroutine(NextState(nextTurn));
        }

        #endregion

        #region FSM

        public override void OnEnterState()
        {
            base.OnEnterState();
            GameData.RuntimeGame.StartCurrentPlayerTurn();
        }

        #endregion

        private IEnumerator NextState(BaseBattleState next)
        {
            yield return new WaitForSeconds(TimeUntilFirstTurn);
            OnNextState(next);
        }
    }
}