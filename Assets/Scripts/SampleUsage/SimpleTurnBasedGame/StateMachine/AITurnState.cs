using System.Collections;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class AITurnState : TurnState
    {
        private const float AiDoTurnDelay = 1;
        private const float AiFinishTurnDelay = 3;

        private Coroutine AiDoTurnRoutine { get; set; }
        private Coroutine AiFinishTurnRoutine { get; set; }

        //create AI module here

        public override IEnumerator StartTurn()
        {
            yield return base.StartTurn();

            //call do turn routine
            AiDoTurnRoutine = StartCoroutine(AiDoTurn());
            //call finish turn routine
            AiFinishTurnRoutine = StartCoroutine(AiFinishTurn(AiFinishTurnDelay));
        }

        private IEnumerator AiDoTurn()
        {
            yield return new WaitForSeconds(AiDoTurnDelay);
            if (!IsMyTurn())
                yield break;

            //Implement AI turn here
        }

        private IEnumerator AiFinishTurn(float delay)
        {
            yield return new WaitForSeconds(delay);
            if (!IsMyTurn())
                yield break;

            StartCoroutine(TimeOut());
        }

        public override void Restart()
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