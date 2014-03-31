using Monopoly.Banker;
using Monopoly.JailRoster;
using Monopoly.Players;
using NUnit.Framework;

namespace MonopolyTests.JailRosterTests
{
    [TestFixture]
    public class JailRosterTests
    {
        private IJailRoster jailRoster;
        private IPlayer player;

        [SetUp]
        public void SetUp()
        {
            player = new Player(0, "horse");
            var banker = new TraditionalBanker(new[] { player.Id });
            jailRoster = new TraditionalJailRoster(banker);
        }

        [Test]
        public void TestJailRosterReturnsTrueWhenPlayerIsInJail()
        {
            jailRoster.Add(player.Id);
            Assert.That(jailRoster.IsInJail(player.Id), Is.True);
        }

        [Test]
        public void TestJailRosterReturnsFalseWhenPlayerIsNotInJail()
        {
            var car = new Player(0, "car");
            Assert.That(jailRoster.IsInJail(car.Id), Is.False);
        }

        [Test]
        public void TestAddTurnForPlayerIncrementsTurnsForPlayer()
        {
            jailRoster.Add(player.Id);
            jailRoster.AddTurnFor(player.Id);

            Assert.That(jailRoster.GetTurnsFor(player.Id), Is.EqualTo(1));
        }

        [Test]
        public void TestAdd3TurnsThenGetTurnsForPlayerReturns3()
        {
            jailRoster.Add(player.Id);
            jailRoster.AddTurnFor(player.Id);
            jailRoster.AddTurnFor(player.Id);
            jailRoster.AddTurnFor(player.Id);
            Assert.That(jailRoster.GetTurnsFor(player.Id), Is.EqualTo(3));
        }

        [Test]
        public void TestTwoPlayersInJailAndGetTurnsReturnsCorrectly()
        {
            var player2 = new Player(1, "car");
            jailRoster.Add(player.Id);
            jailRoster.Add(player2.Id);
            jailRoster.AddTurnFor(player.Id);
            jailRoster.AddTurnFor(player.Id);
            jailRoster.AddTurnFor(player2.Id);

            Assert.That(jailRoster.GetTurnsFor(player.Id), Is.EqualTo(2));
            Assert.That(jailRoster.GetTurnsFor(player2.Id), Is.EqualTo(1));
        }

        [Test]
        public void TestRemovingPlayerActuallRemovesPlayer()
        {
            jailRoster.Add(player.Id);
            Assert.That(jailRoster.IsInJail(player.Id), Is.True);

            jailRoster.Remove(player.Id);
            Assert.That(jailRoster.IsInJail(player.Id), Is.False);
        }

        [Test]
        public void TestRemovingPlayerThatIsNotInJailDoesNotThrowException()
        {
            jailRoster.Remove(player.Id);
        }
    }
}
