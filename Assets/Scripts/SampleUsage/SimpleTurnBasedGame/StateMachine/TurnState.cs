using System.Collections;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public abstract class TurnState : BaseBattleState, IPlayerRegister
    {
        protected const float StartTurnDelay = 0;
        protected const float MaxTimeToFinishTurn = 5;

        public IPrimitivePlayer Player { get; protected set; }
        protected Coroutine TimeOutRoutine { get; set; }

        public void RegisterPlayer(IPrimitivePlayer player)
        {
            Player = player;
        }

        #region FSM

        public override void OnEnterState()
        {
            base.OnEnterState();

            //setup timer to end the turn
            TimeOutRoutine = StartCoroutine(TimeOut());

            //start current player turn
            StartCoroutine(StartTurn());
        }

        public override void OnExitState()
        {
            base.OnExitState();
            Restart();
        }

        #endregion

        #region Player Actions

        /// <summary>
        ///     Starts the player turn.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerator StartTurn()
        {
            yield return new WaitForSeconds(StartTurnDelay);
            GameLogic.StartCurrentPlayerTurn();
        }

        /// <summary>
        ///     Finishes the player turn.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerator TimeOut()
        {
            if (TimeOutRoutine != null)
                StopCoroutine(TimeOutRoutine);
            else
                yield return new WaitForSeconds(MaxTimeToFinishTurn);

            TryPassTurn();
        }

        /// <summary>
        ///     Restart the state to the initial configuration and stops all the internal routines.
        /// </summary>
        public override void Restart()
        {
            base.Restart();
            if (TimeOutRoutine != null)
                StopCoroutine(TimeOutRoutine);
            TimeOutRoutine = null;
        }

        /// <summary>
        ///     Checks inside the game logic whether the player of this state can play.
        /// </summary>
        /// <returns></returns>
        public bool IsMyTurn()
        {
            return GameLogic.Token.IsMyTurn(Player);
        }

        /// <summary>
        ///     Passes the turn to the next player.
        /// </summary>
        public void TryPassTurn()
        {
            if (!IsMyTurn())
                return;

            GameLogic.FinishCurrentPlayerTurn();
        }

        #endregion
    }
}