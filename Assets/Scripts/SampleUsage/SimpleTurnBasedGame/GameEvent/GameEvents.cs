using System;
using System.Collections;
using System.Collections.Generic;
using Patterns;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class GameEvents : Observer<GameEvents>
    {
        
    }

    /// <summary>
    /// Broadcast right before the game start event.
    /// </summary>
    public interface IPreGameStart : ISubject
    {
        void OnPreGameStart(List<IPrimitivePlayer> players);
    }

    /// <summary>
    /// Broadcast after the game starts for all the Listeners.
    /// </summary>
    public interface IStartGame : ISubject
    {
        void OnStartGame(IPrimitivePlayer starter);
    }

    /// <summary>
    /// Broadcast after a game is finished for all the Listeners.
    /// </summary>
    public interface IFinishGame : ISubject
    {
        void OnFinishGame(IPrimitivePlayer winner);
    }

    /// <summary>
    /// Broadcast after a player starts the turn for all the Listeners.
    /// </summary>
    public interface IStartPlayerTurn : ISubject
    {
        void OnStartPlayerTurn(IPrimitivePlayer player);
    }

    /// <summary>
    /// Broadcast after a player finishes the turn for all the Listeners.
    /// </summary>
    public interface IFinishPlayerTurn : ISubject
    {
        void OnFinishPlayerTurn(IPrimitivePlayer player);
    }
}