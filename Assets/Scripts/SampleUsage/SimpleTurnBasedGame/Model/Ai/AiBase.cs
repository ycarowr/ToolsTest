﻿using System;
using System.Linq;
using Extensions;

namespace SimpleTurnBasedGame.AI
{
    /// <summary>
    /// Base for all the Artificial Intelligence of the game.
    /// </summary>
    public abstract class AiBase
    {
        protected IPrimitiveGame Game { get; }
        protected IPrimitivePlayer Player { get; }

        protected AiBase(IPrimitivePlayer player, IPrimitiveGame game)
        {
            Game = game;
            Player = player;
        }

        public abstract MoveType GetBestMove();

        protected MoveType[] GetAllMoves()
        {
            return Enum.GetValues(typeof(MoveType)).Cast<MoveType>().ToArray();
        }

        protected MoveType GetRandomExcept(MoveType move)
        {
            var allMoves = GetAllMoves().ToList();
            allMoves.Remove(move);
            return allMoves.RandomItem();
        }
    }
}
