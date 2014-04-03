using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Monopoly.Banker;
using Monopoly.GameDriver;
using Monopoly.Turns;
using NUnit.Framework;

namespace MonopolyTests.GameTests
{
    [TestFixture]
    public class GameTests
    {
        private Game game;
        private IEnumerable<Int32> playerIds;
        private TraditionalTurnFactory turnFactory;

        [SetUp]
        public void SetUp()
        {
            playerIds = new[] { 0, 1, 2 };
            var banker = new TraditionalBanker(playerIds);
            turnFactory = new TraditionalTurnFactory(banker);
            game = new Game(playerIds, turnFactory);
        }
        
        [Test]
        public void TestCreateGameWithTwoPlayers()
        {
            Assert.That(game.PlayerIds.Count(), Is.EqualTo(3));
            Assert.That(game.PlayerIds.Contains(0), Is.True);
            Assert.That(game.PlayerIds.Contains(1), Is.True);
            Assert.That(game.PlayerIds.Contains(2), Is.True);
        }

        [Test]
        public void TestPlayerOrderIsRandom()
        {
            var games = new List<Game>();

            for (var i = 0; i < 50; i++)
                games.Add(new Game(playerIds, turnFactory));

            var playersStartWithZero = games.Any(g => g.PlayerIds.First() == 0);
            var playersStartWithOne = games.Any(g => g.PlayerIds.First() == 1);
            var playersStartWithTwo = games.Any(g => g.PlayerIds.First() == 2);

            Assert.That(playersStartWithZero && playersStartWithOne && playersStartWithTwo, Is.True);
        }

        [Test]
        public void TestTwentyRoundsPlayedAndEachPlayerPlayedAllTwenty()
        {
            var game = new Game(playerIds, turnFactory);
            game.Play();

            Assert.That(game.Rounds, Is.EqualTo(20));
            Assert.That(game.GetTotalTurnsFor(0), Is.EqualTo(20));
            Assert.That(game.GetTotalTurnsFor(1), Is.EqualTo(20));
            Assert.That(game.GetTotalTurnsFor(2), Is.EqualTo(20));
        }

        [Test]
        public void TestThatOrderOfPlayersStayedTheSameDuringGame()
        {
            var playersOrder = String.Format("{0},{1},{2}",
                                game.PlayerIds.First(), game.PlayerIds.ElementAt(1), game.PlayerIds.ElementAt(2));
            var turns = String.Empty;
            game.Play();
            var turnSummary = game.GetTurnsSummary();
            var rounds = Regex.Matches(turnSummary, playersOrder);

            Assert.That(rounds.Count, Is.EqualTo(20));
        }
    }
}
