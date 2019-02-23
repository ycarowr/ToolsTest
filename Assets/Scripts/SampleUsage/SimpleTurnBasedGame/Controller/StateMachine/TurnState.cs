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

        //timeout 
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

        void IStartedPlayerTurn.OnStartedCurrentPlayerTurn(IPrimitivePlayer player)
        {
            GameEvents.Instance.Notify<IStartPlayerTurn>(i => i.OnStartPlayerTurn(player));
            Log("OnStarted " + Player.Seat + " Player Turn");
        }

        void IFinishedPlayerTurn.OnFinishedCurrentPlayerTurn(IPrimitivePlayer player)
        {
            GameEvents.Instance.Notify<IFinishedPlayerTurn>(i => i.OnFinishedCurrentPlayerTurn(player));
            Log("OnFinished " + Player.Seat + " Player Turn");
            NextTurn();
        }
        
        #endregion

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
        public virtual IEnumerator TimeOut(float time = TimeOutDelay)
        {
            if (TimeOutRoutine != null)
                StopCoroutine(TimeOutRoutine);
            else
                yield return new WaitForSeconds(time);

            TryPassTurn();
        }

        /// <summary>
        ///     Check if the player can pass the turn and passes the turn to the next player.
        /// </summary>
        public bool TryPassTurn()
        {
            Debug.Log("Try pass turn");
            if (!IsMyTurn())
                return false;
            Debug.Log("pass the turn");
            FinishPlayerTurnStep.Execute();
            return true;
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

        /// <summary>
        /// Switches the turn according to the next player. 
        /// </summary>
        private void NextTurn()
        {
            var nextPlayer = RuntimeGame.Token.NextPlayer;
            var nextState = Fsm.GetPlayer(nextPlayer);
            OnNext(nextState);
        }
    }
}