using System.Collections.Generic;
using Patterns;
using SimpleTurnBasedGame;

namespace SimpleTurnBasedGame.Infrastructure
{
    public class TokenBuilder : DataBuilder<TokenCurrentPlayer>
    {
        private int currentIndex;
        private List<IPrimitivePlayer> defaultPlayers;
        private int startIndex;

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

        public TokenBuilder WithStartIndex(int startIndex)
        {
            this.startIndex = startIndex;
            return this;
        }

        public TokenBuilder WithCurrentIndex(int currentIndex)
        {
            this.currentIndex = currentIndex;
            return this;
        }

        public override TokenCurrentPlayer Build()
        {
            return new TokenCurrentPlayer(defaultPlayers, startIndex, currentIndex);
        }
    }
}