using System;
using Monopoly.Banker;
using Monopoly.JailRoster;
using Monopoly.Players;
using NUnit.Framework;

namespace MonopolyTests.JailRosterTests
{
    [TestFixture]
    public class TraditionalJailRosterTests
    {
        private TraditionalJailRoster jailRoster;
        private Int32 playerId;
        private TraditionalBanker banker;

        [SetUp]
        public void SetUp()
        {
            playerId = 0;
            banker = new TraditionalBanker(new[] { playerId });
            jailRoster = new TraditionalJailRoster(banker);
        }

        [Test]
        public void TestJailRosterReturnsTrueWhenPlayerIsInJail()
        {
            jailRoster.Add(playerId);
            Assert.That(jailRoster.IsInJail(playerId), Is.True);
        }

        [Test]
        public void TestJailRosterReturnsFalseWhenPlayerIsNotInJail()
        {
            var playerId = 0;
            Assert.That(jailRoster.IsInJail(playerId), Is.False);
        }

        [Test]
        public void TestAddTurnForPlayerIncrementsTurnsForPlayer()
        {
            jailRoster.Add(playerId);
            jailRoster.AddTurnFor(playerId);

            Assert.That(jailRoster.GetTurnsFor(playerId), Is.EqualTo(1));
        }

        [Test]
        public void TestAddThreeTurnsThenGetTurnsForPlayerReturnsThree()
        {
            jailRoster.Add(playerId);
            jailRoster.AddTurnFor(playerId);
            jailRoster.AddTurnFor(playerId);
            jailRoster.AddTurnFor(playerId);
            Assert.That(jailRoster.GetTurnsFor(playerId), Is.EqualTo(3));
        }

        [Test]
        public void TestTwoPlayersInJailAndGetTurnsReturnsCorrectly()
        {
            var player2 = new Player(1, "car");
            jailRoster.Add(playerId);
            jailRoster.Add(player2.Id);
            jailRoster.AddTurnFor(playerId);
            jailRoster.AddTurnFor(playerId);
            jailRoster.AddTurnFor(player2.Id);

            Assert.That(jailRoster.GetTurnsFor(playerId), Is.EqualTo(2));
            Assert.That(jailRoster.GetTurnsFor(player2.Id), Is.EqualTo(1));
        }

        [Test]
        public void TestRemovingPlayerActuallRemovesPlayer()
        {
            jailRoster.Add(playerId);
            Assert.That(jailRoster.IsInJail(playerId), Is.True);

            jailRoster.Remove(playerId);
            Assert.That(jailRoster.IsInJail(playerId), Is.False);
        }

        [Test]
        public void TestRemovingPlayerWithFineChargesFineAndReleasesPlayer()
        {
            jailRoster.Add(playerId);
            jailRoster.RemoveWithFine(playerId);

            Assert.That(banker.GetBalanceFor(playerId), Is.EqualTo(1500 - jailRoster.GetJailFine()));
        }

        [Test]
        public void TestRemovingPlayerThatIsNotInJailDoesNotThrowException()
        {
            jailRoster.Remove(playerId);
        }
    }
}
