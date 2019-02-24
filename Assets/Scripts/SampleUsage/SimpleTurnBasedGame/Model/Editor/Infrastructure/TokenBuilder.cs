using System.Collections.Generic;
using Patterns;
using SimpleTurnBasedGame;

namespace SimpleTurnBasedGame.Infrastructure
{
    public class TokenBuilder : DataBuilder<TokenTurnLogic>
    {
        private PlayerSeat currentIndex;
        private List<IPrimitivePlayer> defaultPlayers;
        private PlayerSeat startIndex;

        public TokenBuilder(List<IPrimitivePlayer> players)
        {
            defaultPlayers = players;
        }

        public TokenBuilder() : this(new List<IPrimitivePlayer> {(Player) A.Player()})
        {
        }

        public TokenBuilder WithPlayers(List<IPrimitivePlayer> players)
        {
            defaultPlayers = players;
            return this;
        }

        public TokenBuilder WithStartSeat(PlayerSeat start)
        {
            this.startIndex = start;
            return this;
        }

        public TokenBuilder WithCurrentSeat(PlayerSeat current)
        {
            this.currentIndex = current;
            return this;
        }

        public override TokenTurnLogic Build()
        {
            return new TokenTurnLogic(defaultPlayers, startIndex, currentIndex);
        }
    }
}