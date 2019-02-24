using System.Collections;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public abstract class TurnState : BaseBattleState, 
        IRegisterPlayer, 
        IFinishPlayerTurn
    {
        public IPrimitivePlayer Player { get; protected set; }

        //Timers
        protected const float StartTurnDelay = 1;
        protected const float TimeOutDelay = 5;

        //Turn Steps
        protected StartPlayerTurn StartPlayerTurnStep { get; set; }
        protected FinishPlayerTurn FinishPlayerTurnStep { get; set; }

        //Player Choices
        protected DoDamage DoDamage { get; set; }
        protected DoHeal DoHeal { get; set; }
//        protected DoRandom DoRandom { get; set; }

        //timeout 
        protected Coroutine TimeOutRoutine { get; set; }


        #region Dependencies
        
        public void RegisterPlayer(IPrimitivePlayer player)
        {
            Player = player;
        }

        public override void RegisterRuntimeGame(IPrimitiveGame game)
        {
            base.RegisterRuntimeGame(game);
            StartPlayerTurnStep = new StartPlayerTurn(game);
            FinishPlayerTurnStep = new FinishPlayerTurn(game);
            DoDamage = new DoDamage(game);
            DoHeal = new DoHeal(game);
        }

        #endregion

        #region FSM Controller

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

        #region Controller, Player <-- Model

        void IFinishPlayerTurn.OnFinishPlayerTurn(IPrimitivePlayer player)
        {
            if (IsMyTurn())
                NextTurn();
        }

        #endregion

        #region Controller, Player --> Model

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
        ///     Check if the player can pass the turn and passes the turn to the next player.
        /// </summary>
        public bool TryPassTurn()
        {
            if (!IsMyTurn())
                return false;

            FinishPlayerTurnStep.Execute();
            return true;
        }

        public bool TryRandom()
        {
            if (!IsMyTurn())
                return true;

            return false;
        }

        public bool TryHeal()
        {
            if (!IsMyTurn())
                return false;

            DoHeal.Execute();
            TryPassTurn();
            return true;
        }

        public bool TryDamage()
        {
            if (!IsMyTurn())
                return false;

            DoDamage.Execute();
            TryPassTurn();
            return true;
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
        /// Return the Opponent of this player.
        /// </summary>
        /// <returns></returns>
        public IPrimitivePlayer GetOpponent()
        {
            return RuntimeGame.Token.GetOpponent(Player);
        }

        #endregion

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
        ///     Restart the state to the initial configuration and stops all the internal routines.
        /// </summary>
        public virtual void Restart()
        {
            if (TimeOutRoutine != null)
                StopCoroutine(TimeOutRoutine);
            TimeOutRoutine = null;
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