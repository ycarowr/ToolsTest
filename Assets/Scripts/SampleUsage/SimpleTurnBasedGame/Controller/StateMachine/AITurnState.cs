using SimpleTurnBasedGame.AI;
using System.Collections;
using UnityEngine;
using Random = System.Random;

namespace SimpleTurnBasedGame
{
    public class AiTurnState : TurnState
    {
        private const float AiDoTurnDelay = 1;
        private const float AiFinishTurnDelay = 3;
        private Coroutine AiFinishTurnRoutine { get; set; }
        private AiModule AiModule { get; set; }

        [SerializeField] private bool isTesting = false;
        [SerializeField] private AiArchetype testAi;

        public override void InjectDependencies(IPrimitivePlayer player, IPrimitiveGame game)
        {
            base.InjectDependencies(player, game);
            AiModule = new AiModule(player, game);
            if(isTesting)
                AiModule.SwapAiToArchetype(testAi);
        }

        protected override IEnumerator StartTurn()
        {
            yield return base.StartTurn();

            //call do turn routine
            StartCoroutine(AiDoTurn());
            //call finish turn routine
            AiFinishTurnRoutine = StartCoroutine(AiFinishTurn(AiFinishTurnDelay));
        }

        private IEnumerator AiDoTurn()
        {
            yield return new WaitForSeconds(AiDoTurnDelay);
            if (!IsMyTurn())
                yield break;

            var bestMove = AiModule.GetBestMove();
            ProcessMove(bestMove);
        }

        private IEnumerator AiFinishTurn(float delay)
        {
            yield return new WaitForSeconds(delay);
            if (!IsMyTurn())
                yield break;

            StartCoroutine(TimeOut());
        }

        protected override void Restart()
        {
            base.Restart();
            ResetTurnRoutine();
        }

        private void ResetTurnRoutine()
        {
            if (AiFinishTurnRoutine != null)
                StopCoroutine(AiFinishTurnRoutine);
            AiFinishTurnRoutine = null;
        }
    }
}