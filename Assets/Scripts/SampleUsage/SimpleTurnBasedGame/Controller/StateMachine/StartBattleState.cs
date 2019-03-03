using System.Collections;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class StartBattleState : BaseBattleState, IStartGame
    {
        private const float TimeUntilFirstTurn = 3;
        private StartGame StartGameStep { get; set; }

        #region FSM

        public override void OnInitialize()
        {
            base.OnInitialize();
            StartGameStep = new StartGame(GameData.RuntimeGame);
        }

        public override void OnEnterState()
        {
            base.OnEnterState();
            StartGameStep.Execute();
        }

        #endregion

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
    }
}