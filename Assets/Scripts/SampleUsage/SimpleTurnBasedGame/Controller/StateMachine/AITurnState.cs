﻿using SimpleTurnBasedGame.AI;
using System.Collections;
using UnityEngine;
using Random = System.Random;

namespace SimpleTurnBasedGame
{
    public class AiTurnState : TurnState
    {
        private const float AiDoTurnDelay = 2.5f;
        private const float AiFinishTurnDelay = 3.5f;
        private Coroutine AiFinishTurnRoutine { get; set; }
        private AiModule AiModule { get; set; }
        public override bool IsAi => isAi;
        [Tooltip("Whether this player is AI or not.")]
        [SerializeField] private bool isAi = false;
        [SerializeField] private AiArchetype aiArchetype;

        public override void OnInitialize()
        { 
            base.OnInitialize();
            //create ai
            AiModule = new AiModule(Player, RuntimeGame);
            AiModule.SwapAiToArchetype(aiArchetype);
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

            if (!isAi)
                yield return 0;

            var bestMove = AiModule.GetBestMove();
            ProcessMove(bestMove);
        }

        private IEnumerator AiFinishTurn(float delay)
        {
            yield return new WaitForSeconds(delay);
            if (!IsMyTurn())
                yield break;

            if (!isAi)
                yield return 0;

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