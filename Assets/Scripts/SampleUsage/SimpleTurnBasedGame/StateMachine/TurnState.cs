using System.Collections;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public abstract class TurnState : BaseBattleState, IPlayerRegister, IStartedPlayerTurn, IFinishedPlayerTurn
    {
        public IPrimitivePlayer Player { get; protected set; }

        //timers
        protected const float StartTurnDelay = 1;
        protected const float TimeOutDelay = 5;
        
        //Turn Steps
        protected StartPlayerTurn StartPlayerTurnStep { get; set; }
        protected FinishPlayerTurn FinishPlayerTurnStep { get; set; }

        protected Coroutine TimeOutRoutine { get; set; }

        public void RegisterPlayer(IPrimitivePlayer player)
        {
            Player = player;
        }

        public override void RegisterRuntimeGame(IPrimitiveGame game)
        {
            base.RegisterRuntimeGame(game);
            StartPlayerTurnStep = new StartPlayerTurn(game, this);
            FinishPlayerTurnStep = new FinishPlayerTurn(game, this);
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
            StartPlayerTurnStep.Execute();
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
                yield return new WaitForSeconds(TimeOutDelay);

            TryPassTurn();
        }

        /// <summary>
        ///     Passes the turn to the next player.
        /// </summary>
        public void TryPassTurn()
        {
            if (!IsMyTurn())
                return;

            FinishPlayerTurnStep.Execute();
        }

        /// <summary>
        ///     Restart the state to the initial configuration and stops all the internal routines.
        /// </summary>
        public virtual void Restart()
        {
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
            return RuntimeGame.Token.IsMyTurn(Player);
        }

        void IStartedPlayerTurn.OnStartedCurrentPlayerTurn(IPrimitivePlayer player)
        {
            Log("OnStarted " + Player.Seat + " Player Turn");
        }

        void IFinishedPlayerTurn.OnFinishedCurrentPlayerTurn(IPrimitivePlayer player)
        {
            Log("OnFinished "+ Player.Seat + " Player Turn");

            NextTurn();
        }

        private void NextTurn()
        {
            var nextPlayer = RuntimeGame.Token.NextPlayer;
            var nextState = Fsm.GetPlayerTurn(nextPlayer);
            OnNext(nextState);
        }


        #endregion
    }
}