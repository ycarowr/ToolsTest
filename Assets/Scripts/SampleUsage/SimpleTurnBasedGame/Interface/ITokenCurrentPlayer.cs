using System.Collections.Generic;

namespace SimpleTurnBasedGame
{
    public interface ITokenCurrentPlayer
    {
        /// <summary>
        ///     List with all the players that are playing the match.
        /// </summary>
        List<IPrimitivePlayer> Players { get; }

        /// <summary>
        ///     Quantity of players playing this match.
        /// </summary>
        int QuantPlayers { get; }

        /// <summary>
        ///     Duration of the match in turns.
        /// </summary>
        int TurnCount { get; }

        /// <summary>
        ///     Current player playing this turn.
        /// </summary>
        IPrimitivePlayer CurrentPlayer { get; }

        /// <summary>
        ///     Player that started the match.
        /// </summary>
        IPrimitivePlayer StarterPlayer { get; }

        /// <summary>
        ///     Next player to play.
        /// </summary>
        IPrimitivePlayer NextPlayer { get; }

        /// <summary>
        ///     Finds the next player and turns it into the current player.
        /// </summary>
        void UpdateCurrentPlayerIndex();

        /// <summary>
        ///     Calculus to decide which player starts the match.
        /// </summary>
        void DecideStarterPlayerIndex();

        /// <summary>
        ///     Returns whether is the player turn or not.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        bool IsMyTurn(IPrimitivePlayer player);

        /// <summary>
        /// Returns the index of a player. -1 if the player is not registered yet.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        int GetPlayerIndex(IPrimitivePlayer player);
    }
}