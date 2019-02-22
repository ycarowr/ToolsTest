using System;
using System.Collections.Generic;
using SimpleTurnBasedGame.Infrastructure;
using NUnit.Framework;

namespace SimpleTurnBasedGame.Tests
{
    public class GameLogicTests
    {
        public class TokenCurrentPlayerTest
        {
            [Test]
            public void CreateTokenWithZeroPlayers_ArgumentError()
            {
                var emptyList = new List<IPrimitivePlayer>();

                void CreateBrokenToken()
                {
                    var token = (TokenCurrentPlayer) A.Token().WithPlayers(emptyList);
                }

                Assert.Throws<ArgumentException>(CreateBrokenToken);
            }

            [Test]
            public void CreateTokenWithNegativeStartIndex_ArgumentError()
            {
                void CreateBrokenToken(int invalidStartIndex = -1)
                {
                    var token = (TokenCurrentPlayer) A.Token().WithStartIndex(invalidStartIndex);
                }

                Assert.Throws<ArgumentException>(() => CreateBrokenToken());
            }

            [Test]
            public void CreateTokenWithTooBigStartIndex_ArgumentError()
            {
                void CreateBrokenToken()
                {
                    var players = new List<IPrimitivePlayer> {(Player) A.Player()};
                    var token = (TokenCurrentPlayer) A.Token()
                        .WithPlayers(players)
                        .WithStartIndex(players.Count + 1);
                }

                Assert.Throws<ArgumentException>(CreateBrokenToken);
            }

            [Test]
            public void CreateTokenWithNegativeCurrentIndex_ArgumentError()
            {
                void CreateBrokenToken(int invalidCurrentIndex = -1)
                {
                    var token = (TokenCurrentPlayer) A.Token().WithCurrentIndex(invalidCurrentIndex);
                }

                Assert.Throws<ArgumentException>(() => CreateBrokenToken());
            }

            [Test]
            public void CreateTokenWithTooBigCurrentIndex_ArgumentError()
            {
                void CreateBrokenToken()
                {
                    var players = new List<IPrimitivePlayer> {(Player) A.Player()};
                    var token = (TokenCurrentPlayer) A.Token()
                        .WithPlayers(players)
                        .WithCurrentIndex(players.Count + 1);
                }

                Assert.Throws<ArgumentException>(CreateBrokenToken);
            }

            [Test]
            public void CreateTokenWith2Players_RegularInitialState()
            {
                var player = (Player) A.Player().WithSeat(PlayerSeat.Bottom);
                var player1 = (Player) A.Player().WithSeat(PlayerSeat.Top);
                var players = new List<IPrimitivePlayer> {player, player1};
                var token = (TokenCurrentPlayer) A.Token().WithPlayers(players);

                //initial state has turn count equals to zero
                Assert.AreEqual(token.TurnCount, 0);
                //on initial state starter and current are the same
                Assert.AreEqual(token.StarterPlayerIndex, token.CurrentPlayerIndex);
                //current index has to be smaller than quantity
                Assert.Less(token.CurrentPlayerIndex, players.Count);
            }

            [Test]
            public void UpdatePlayerIndex10TimesFrom0()
            {
                var player = (Player) A.Player().WithSeat(PlayerSeat.Bottom);
                var player1 = (Player) A.Player().WithSeat(PlayerSeat.Top);
                var players = new List<IPrimitivePlayer> {player, player1};
                var token = (TokenCurrentPlayer) A.Token().WithPlayers(players);
                var quantPlayers = players.Count;

                const int firstPlayerIndex = 0;
                token.SetCurrentIndex(firstPlayerIndex);
                token.SetStarterIndex(firstPlayerIndex);

                const int n = 10;
                //Update the index n times
                for (var i = 0; i < n; i++) token.UpdateCurrentPlayerIndex();

                //turn count has to be the same as n
                Assert.AreEqual(token.TurnCount, n);
                //+1 because we don't update the index on the first attempt
                var turnMod = n + 1 % quantPlayers;
                Assert.AreEqual(token.CurrentPlayerIndex, (turnMod + firstPlayerIndex) % quantPlayers);
            }

            [Test]
            public void UpdateTokenFrom0_IndexRemainsTheSame()
            {
                const int firstPlayerIndex = 0;
                var token = (TokenCurrentPlayer) A.Token()
                    .WithCurrentIndex(firstPlayerIndex)
                    .WithStartIndex(firstPlayerIndex);


                token.UpdateCurrentPlayerIndex();

                //set indexes to zero
                const int expectedIndex = firstPlayerIndex;
                //current remains zero
                Assert.AreEqual(token.CurrentPlayerIndex, firstPlayerIndex);
                //next remains zero + 1
                Assert.AreEqual(token.NextPlayerIndex, expectedIndex);
            }

            [Test]
            public void GetNextIndexFromZero_IndexIsOne()
            {
                const int firstPlayerIndex = 0;
                var player = (Player) A.Player().WithSeat(PlayerSeat.Bottom);
                var player1 = (Player) A.Player().WithSeat(PlayerSeat.Top);
                var players = new List<IPrimitivePlayer> {player, player1};
                var token = (TokenCurrentPlayer) A.Token()
                    .WithPlayers(players)
                    .WithCurrentIndex(firstPlayerIndex)
                    .WithStartIndex(firstPlayerIndex);

                //set indexes to zero
                const int expectedIndex = 1;
                Assert.AreEqual(token.NextPlayerIndex, expectedIndex);
            }
        }
    }
}