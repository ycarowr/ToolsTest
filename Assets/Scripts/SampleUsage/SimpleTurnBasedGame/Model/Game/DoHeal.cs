using System.Collections.Generic;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     Damage Logic Implementation
    /// </summary>
    public class DoHeal : TurnStep
    {
        private const int HealAmount = 1;
        public DoHeal(IPrimitiveGame game) : base(game)
        {

        }

        /// <summary>
        /// Execution of the heal logic.
        /// </summary>
        public void Execute()
        {
            if (!Game.IsTurnInProgress)
                return;

            if (!Game.IsGameStarted)
                return;

            if (Game.IsGameFinished)
                return;

            //get players
            var source = Game.Token.CurrentPlayer as IHealer;
            var target = source as IHealable;

            //do heal
            var healedAmount = source.DoHeal(target, HealAmount);

            //dispatch heal
            OnDoneHeal(source, target, healedAmount);
        }

        /// <summary>
        /// Dispatch heal to the listeners.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="amount"></param>
        private void OnDoneHeal(IHealer source, IHealable target, int amount)
        {
            GameEvents.Instance.Notify<IDoHeal>(i => i.OnHeal(source, target, amount));
        }
    }
}