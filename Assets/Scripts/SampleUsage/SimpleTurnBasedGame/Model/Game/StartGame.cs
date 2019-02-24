﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    /// <inheritdoc />
    /// <summary>
    ///     Start Game Step Implementation.
    /// </summary>
    public class StartGame : TurnStep
    {
        public StartGame(IPrimitiveGame game) : base(game)
        {
            
        }

        /// <summary>
        /// Execution of start game 
        /// </summary>
        public void Execute()
        {
            if (Game.IsGameStarted) return;

            Game.IsGameStarted = true;
            Game.Token.DecideStarterPlayer();

            OnGamePreStarted(Game.Token.Players);
            OnGameStarted(Game.Token.StarterPlayer);
        }

        /// <summary>
        /// Dispatch pre start game event to the listeners
        /// </summary>
        /// <param name="players"></param>
        private void OnGamePreStarted(List<IPrimitivePlayer> players)
        {
            GameEvents.Instance.Notify<IPreGameStart>(i => i.OnPreGameStart(players));
        }

        /// <summary>
        /// Dispatch start game event to the listeners.
        /// </summary>
        /// <param name="starterPlayer"></param>
        private void OnGameStarted(IPrimitivePlayer starterPlayer)
        {
            GameEvents.Instance.Notify<IStartGame>(i => i.OnStartGame(starterPlayer));
        }
    }
}