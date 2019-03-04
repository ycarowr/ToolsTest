using System.Collections;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class StartBattleState : BaseBattleState, IStartGame
    {
        private const float TimeUntilFirstTurn = 3;
        private ProcessStartGame ProcessStartGameStep { get; set; }

        #region Model --> Controller

        void IStartGame.OnStartGame(IPrimitivePlayer starter)
        {
            var nextTurn = Fsm.GetPlayer(starter);
            StartCoroutine(NextState(nextTurn));
        }

        #endregion


        private IEnumerator NextState(BaseBattleState next)
        {
            yield return new WaitForSeconds(TimeUntilFirstTurn);
            OnNextState(next);
        }

        #region FSM

        public override void OnInitialize()
        {
            base.OnInitialize();
            ProcessStartGameStep = new ProcessStartGame(GameData.RuntimeGame);
        }

        public override void OnEnterState()
        {
            base.OnEnterState();
            ProcessStartGameStep.Execute();
        }

        #endregion
    }
}