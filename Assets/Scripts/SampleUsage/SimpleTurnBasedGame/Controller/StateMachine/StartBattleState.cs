using System.Collections;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class StartBattleState : BaseBattleState, IStartGame
    {
        private const float TimeUntilFirstTurn = 3;
        private StartGame StartGameStep { get; set; }

        #region FSM

        public override void RegisterRuntimeGame(IPrimitiveGame game)
        {
            base.RegisterRuntimeGame(game);

            StartGameStep = new StartGame(game);
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
            StartCoroutine(OnNextState(nextTurn));
        }

        #endregion


        private IEnumerator OnNextState(BaseBattleState next)
        {
            yield return new WaitForSeconds(TimeUntilFirstTurn);
            OnNext(next);
        }
    }
}