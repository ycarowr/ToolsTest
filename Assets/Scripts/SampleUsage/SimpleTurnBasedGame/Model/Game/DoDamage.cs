using System.Collections.Generic;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     Damage Logic Implementation
    /// </summary>
    public class DoDamage : TurnStep
    {
        private const int DamageAmount = 1;
        public DoDamage(IPrimitiveGame game) : base(game)
        {

        }

        /// <summary>
        /// Execution of the damage logic.
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
            var source = Game.Token.CurrentPlayer as IAttackable;
            var target = Game.Token.GetOpponent(source as IPrimitivePlayer) as IDamageable;

            //do attack
            var damageDealt = source.DoAttack(target, DamageAmount);

            //dispatch damage
            OnDoneDamage(source, target, damageDealt);
        }

        /// <summary>
        /// Dispatch damage dealt to the listeners.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="amount"></param>
        private void OnDoneDamage(IAttackable source, IDamageable target, int amount)
        {
            GameEvents.Instance.Notify<IDoDamage>(i => i.OnDamage(source, target, amount));
        }
    }
}