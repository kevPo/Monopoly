using Monopoly;
using Monopoly.TraditionalMonopoly;
using NUnit.Framework;

namespace MonopolyTests
{
    [TestFixture]
    public class JailRosterTests
    {
        private IJailRoster jailRoster;
        private IPlayer player;

        [SetUp]
        public void SetUp()
        {
            jailRoster = new TraditionalJailRoster();
            player = new Player("horse", 200);
        }

        [Test]
        public void TestJailRosterReturnsTrueWhenPlayerIsInJail()
        {
            jailRoster.Add(player);
            Assert.That(jailRoster.IsInJail(player), Is.True);
        }

        [Test]
        public void TestJailRosterReturnsFalseWhenPlayerIsNotInJail()
        {
            var car = new Player("car", 2000);
            Assert.That(jailRoster.IsInJail(car), Is.False);
        }

        [Test]
        public void TestAddTurnForPlayerIncrementsTurnsForPlayer()
        {
            jailRoster.Add(player);
            jailRoster.AddTurnFor(player);

            Assert.That(jailRoster.GetTurnsFor(player), Is.EqualTo(1));
        }

        [Test]
        public void TestAdd3TurnsThenGetTurnsForPlayerReturns3()
        {
            jailRoster.Add(player);
            jailRoster.AddTurnFor(player);
            jailRoster.AddTurnFor(player);
            jailRoster.AddTurnFor(player);
            Assert.That(jailRoster.GetTurnsFor(player), Is.EqualTo(3));
        }

        [Test]
        public void TestTwoPlayersInJailAndGetTurnsReturnsCorrectly()
        {
            var player2 = new Player("car", 200);
            jailRoster.Add(player);
            jailRoster.Add(player2);
            jailRoster.AddTurnFor(player);
            jailRoster.AddTurnFor(player);
            jailRoster.AddTurnFor(player2);

            Assert.That(jailRoster.GetTurnsFor(player), Is.EqualTo(2));
            Assert.That(jailRoster.GetTurnsFor(player2), Is.EqualTo(1));
        }

        [Test]
        public void TestRemovingPlayerActuallRemovesPlayer()
        {
            jailRoster.Add(player);
            Assert.That(jailRoster.IsInJail(player), Is.True);

            jailRoster.Remove(player);
            Assert.That(jailRoster.IsInJail(player), Is.False);
        }

        [Test]
        public void TestRemovingPlayerThatIsNotInJailDoesNotThrowException()
        {
            jailRoster.Remove(player);
        }
    }
}
