using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace SimpleTurnBasedGame
{
    /// <summary>
    ///     This class decides which player goes first and which player goes next.
    ///     In order to accomplish it, it keeps track of the current player.
    ///     The implementation is done using a single index iterating over a list of players.
    /// </summary>
    public class TokenCurrentPlayer : ITokenCurrentPlayer
    {
        public TokenCurrentPlayer(List<IPrimitivePlayer> players, int startIndex = 0, int currentIndex = 0)
        {
            if (players == null)
                throw new ArgumentException("A Null List is not a valid argument to Create a Token");
            if (players.Count < 1)
                throw new ArgumentException("Invalid number of players: " + players.Count);
            if (startIndex > players.Count - 1 || startIndex < 0)
                throw new ArgumentException("Invalid Start Index: " + startIndex);
            if (currentIndex > players.Count - 1 || currentIndex < 0)
                throw new ArgumentException("Invalid Current Index: " + currentIndex);

            Players = players;
            Restart();
            StarterPlayerIndex = startIndex;
            CurrentPlayerIndex = currentIndex;
        }

        public int NextPlayerIndex => (CurrentPlayerIndex + 1) % QuantPlayers;
        public int CurrentPlayerIndex { get; private set; }
        public int StarterPlayerIndex { get; private set; }
        public List<IPrimitivePlayer> Players { get; }
        public int TurnCount { get; private set; }

        public IPrimitivePlayer CurrentPlayer => Players[CurrentPlayerIndex];
        public IPrimitivePlayer NextPlayer => Players[NextPlayerIndex];
        public IPrimitivePlayer StarterPlayer => Players[StarterPlayerIndex];
        public int QuantPlayers => Players.Count;

        bool ITokenCurrentPlayer.IsMyTurn(IPrimitivePlayer player)
        {
            return CurrentPlayer == player;
        }

        /// <summary>
        ///     Assign next player to the current player.
        /// </summary>
        public void UpdateCurrentPlayerIndex()
        {
            //increment turn count
            TurnCount++;

            //not on the first turn of the match
            if (TurnCount == 1)
                return;

            //update current player
            CurrentPlayerIndex = NextPlayerIndex;
        }

        /// <inheritdoc />
        /// <summary>
        ///     Decides which player goes first Randomly.
        /// </summary>
        public void DecideStarterPlayerIndex()
        {
            StarterPlayerIndex = Random.Range(0, QuantPlayers);
            CurrentPlayerIndex = StarterPlayerIndex;
        }

        public void Restart()
        {
            DecideStarterPlayerIndex();
            TurnCount = 0;
        }

        public void SetCurrentIndex(int index)
        {
            CurrentPlayerIndex = index;
        }

        public void SetStarterIndex(int index)
        {
            StarterPlayerIndex = index;
        }
    }
}