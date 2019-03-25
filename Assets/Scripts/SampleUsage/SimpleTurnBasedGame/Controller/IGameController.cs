using Patterns.StateMachine;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public interface IGameController : IStateMachineHandler
    {
        MonoBehaviour MonoBehaviour { get; }
        IPlayerTurn GetPlayerController(PlayerSeat seat);
        void StartBattle();
        void EndBattle();
        void RestartGameImmediately();
    }
}