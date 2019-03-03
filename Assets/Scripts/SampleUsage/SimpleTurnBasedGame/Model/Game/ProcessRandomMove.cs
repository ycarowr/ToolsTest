using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class ProcessRandomMove : TurnStep
    {
        private const int BonusByPlayingRandom = 2;

        public ProcessRandomMove(IPrimitiveGame game) : base(game)
        {
            ProcessDamageMove = new DecoratorProcessDamageMove(game);
            ProcessHeal = new DecoratorProcessHeal(game);
        }

        private DecoratorProcessDamageMove ProcessDamageMove { get; }
        private DecoratorProcessHeal ProcessHeal { get; }

        public void Execute()
        {
            var rdn = Random.Range(0, 2);

            //Heads or Tails?
            if (rdn == 0)
                ProcessDamageMove.Execute();
            else
                ProcessHeal.Execute();
        }

        #region Decorators

        private class DecoratorProcessDamageMove : ProcessDamageMove
        {
            public DecoratorProcessDamageMove(IPrimitiveGame game) : base(game)
            {
            }

            protected override int GetDamage()
            {
                return base.GetDamage() + BonusByPlayingRandom;
            }
        }

        private class DecoratorProcessHeal : ProcessHealMove
        {
            public DecoratorProcessHeal(IPrimitiveGame game) : base(game)
            {
            }

            protected override int GetHeal()
            {
                return base.GetHeal() + BonusByPlayingRandom;
            }
        }

        #endregion
    }
}