using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class ProcessRandomMove : ProcessBase
    {
        public int Bonus { get; }
        private ProcessDamagePlus DamagePlus { get; }
        private ProcessHealPlus HealPlus { get; }

        public ProcessRandomMove(IPrimitiveGame game) : base(game)
        {
            Bonus = Game.Configurations.Bonus.Value;

            DamagePlus = new ProcessDamagePlus(game, Bonus);
            HealPlus = new ProcessHealPlus(game, Bonus);
        }

        public void Execute()
        {
            var rdn = Random.Range(0, 2);

            //Heads or Tails?
            if (rdn == 0)
                DamagePlus.Execute();
            else
                HealPlus.Execute();
        }

        //----------------------------------------------------------------------------------------------------------

        #region Decorators

        private class ProcessDamagePlus : ProcessDamageMove
        {
            private int Bonus { get; }

            public ProcessDamagePlus(IPrimitiveGame game, int bonus) : base(game)
            {
                Bonus = bonus;
            }

            protected override int GetDamage()
            {
                return base.GetDamage() + Bonus;
            }
        }

        private class ProcessHealPlus : ProcessHealMove
        {
            private int Bonus { get; }

            public ProcessHealPlus(IPrimitiveGame game, int bonus) : base(game)
            {
            }

            protected override int GetHeal()
            {
                return base.GetHeal() + Bonus;
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}