using System.Collections.Generic;
using Patterns;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class PlayersController : SingletonMB<PlayersController>, IPlayerStateRegister
    {
        private readonly Dictionary<IPrimitivePlayer, TurnState> registerStates =
            new Dictionary<IPrimitivePlayer, TurnState>();

        private readonly Dictionary<IPrimitivePlayer, UIPlayer> registerUIs =
            new Dictionary<IPrimitivePlayer, UIPlayer>();

        [SerializeField] private UIPlayer[] UIs;

        public void RegisterPlayer(TurnState playerTurnState)
        {
            var player = playerTurnState.Player;
            var ui = GetUI(player.Seat);
            registerStates.Add(player, playerTurnState);
            registerUIs.Add(player, ui);
        }

        public UIPlayer GetUI(PlayerSeat seat)
        {
            foreach (var i in UIs)
                if (i.Seat == seat)
                    return i;

            return null;
        }

        public void TryPassTurn(IPrimitivePlayer player)
        {
            registerStates[player].TryPassTurn();
        }
    }
}