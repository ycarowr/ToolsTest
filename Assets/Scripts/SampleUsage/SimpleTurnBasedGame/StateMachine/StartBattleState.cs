
namespace SimpleTurnBasedGame
{
    public class StartBattleState : BaseBattleState
    {
        public override void OnEnterState()
        {
            base.OnEnterState();
            GameLogic.StartGame();
        }
    }
}