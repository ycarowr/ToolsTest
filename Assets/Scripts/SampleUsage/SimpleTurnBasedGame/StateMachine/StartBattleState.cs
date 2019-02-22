using System.Collections;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class StartBattleState : BaseBattleState, IGameStarted
    {
        private const float TimeUntilFirstTurn = 1;
        private StartGame StartGameStep { get; set; }

        public override void RegisterRuntimeGame(IPrimitiveGame game)
        {
            base.RegisterRuntimeGame(game);
            StartGameStep = new StartGame(game, this);
        }

        public override void OnEnterState()
        {
            base.OnEnterState();
            StartGameStep.Execute();
        }

        public void OnGameStarted(IPrimitivePlayer starter)
        {
            Log("Game Started Dispatched");
            var nextTurn = Fsm.GetPlayerTurn(starter);
            StartCoroutine(OnNextState(nextTurn));
        }

        private IEnumerator OnNextState(BaseBattleState next)
        {
            yield return new WaitForSeconds(TimeUntilFirstTurn);
            OnNext(next);
        }
    }
}