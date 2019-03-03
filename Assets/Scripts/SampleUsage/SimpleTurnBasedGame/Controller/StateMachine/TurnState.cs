using System;
using System.Collections;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    [RequireComponent(typeof(GameController))]
    public abstract class TurnState : BaseBattleState, 
        IFinishPlayerTurn
    {
        public IPrimitivePlayer Player { get; protected set; }
        public virtual PlayerSeat Seat { get; }
        public virtual bool IsAi => false;

        //Timers
        protected const float StartTurnDelay = 1;
        protected const float TimeOutDelay = 10;

        //Turn Steps
        protected StartPlayerTurn StartPlayerTurnStep { get; set; }
        protected FinishPlayerTurn FinishPlayerTurnStep { get; set; }

        //Player Moves
        protected ProcessDamageMove ProcessDamageMove { get; set; }
        protected ProcessHealMove ProcessHealMove { get; set; }
        protected ProcessRandomMove ProcessRandomMove { get; set; }

        //timeout 
        protected Coroutine TimeOutRoutine { get; set; }

        #region Dependencies

        public override void OnInitialize()
        {
            base.OnInitialize();

            var game = GameData.RuntimeGame;

            //get player according to the seat
            Player = game.Token.GetPlayer(Seat);

            //register turn state
            GameController.RegisterPlayerState(Player, this);

            //Turn steps
            StartPlayerTurnStep = new StartPlayerTurn(game);
            FinishPlayerTurnStep = new FinishPlayerTurn(game);

            //Moves
            ProcessDamageMove = new ProcessDamageMove(game);
            ProcessHealMove = new ProcessHealMove(game);
            ProcessRandomMove = new ProcessRandomMove(game);
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
        protected virtual IEnumerator StartTurn()
        {
            yield return new WaitForSeconds(StartTurnDelay);
            StartPlayerTurnStep.Execute();
        }

        /// <summary>
        ///     Check if the player can pass the turn and passes the turn to the next player.
        /// </summary>
        protected bool TryPassTurn()
        {
            if (!IsMyTurn())
                return false;

            FinishPlayerTurnStep.Execute();
            return true;
        }

        protected bool TryRandom()
        {
            if (!IsMyTurn())
                return false;

            ProcessRandomMove.Execute();
            TryPassTurn();
            return true;
        }

        protected bool TryHeal()
        {
            if (!IsMyTurn())
                return false;

            ProcessHealMove.Execute();
            TryPassTurn();
            return true;
        }

        protected bool TryDamage()
        {
            if (!IsMyTurn())
                return false;

            ProcessDamageMove.Execute();
            TryPassTurn();
            return true;
        }

        /// <summary>
        ///     Checks inside the game logic whether the player of this state can play.
        /// </summary>
        /// <returns></returns>
        public bool IsMyTurn()
        {
            return GameData.RuntimeGame.Token.IsMyTurn(Player);
        }

        /// <summary>
        /// Return the Opponent of this player.
        /// </summary>
        /// <returns></returns>
        public IPrimitivePlayer GetOpponent()
        {
            return GameData.RuntimeGame.Token.GetOpponent(Player);
        }

        #endregion


        /// <summary>
        /// Processes a move based on its Type.
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        public bool ProcessMove(MoveType move)
        {
            switch (move)
            {
                case MoveType.RandomMove:
                    return TryRandom();
                case MoveType.DamageMove:
                    return TryDamage();
                case MoveType.HealMove:
                    return TryHeal();
                default:
                    throw new ArgumentOutOfRangeException(nameof(move), move, null);
            }
        }

        /// <summary>
        ///     Finishes the player turn.
        /// </summary>
        /// <returns></returns>
        protected virtual IEnumerator TimeOut(float time = TimeOutDelay)
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
            var game = GameData.RuntimeGame;
            var nextPlayer = game.Token.NextPlayer;
            var nextState = Fsm.GetPlayer(nextPlayer);
            OnNextState(nextState);
        }
    }
}