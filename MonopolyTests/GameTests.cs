using System.Linq;
using Monopoly;
using Monopoly.TraditionalMonopoly;
using MonopolyTests.Fakes;
using NUnit.Framework;

namespace MonopolyTests
{
    [TestFixture]
    public class GameTests
    {

        [Test]
        public void TestCreateGameWithTwoPlayersHorseAndCar()
        {
            var players = new [] { new Player("Horse", 0), new Player("Car", 0) };
            var jailRoster = new TraditionalJailRoster();
            var fakeBoard = new FakeBoard(new FakeDice(), players, jailRoster);
            var game = new Game(fakeBoard);
            var gamePlayers = fakeBoard.GetPlayers();

            Assert.That(gamePlayers.Count(), Is.EqualTo(2));
            Assert.That(gamePlayers.Any(p => p.Name == "Horse"), Is.True);
            Assert.That(gamePlayers.Any(p => p.Name == "Car"), Is.True);
        }
    }
}
