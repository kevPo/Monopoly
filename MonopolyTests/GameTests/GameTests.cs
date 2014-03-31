using System.Linq;
using Monopoly.Game;
using Monopoly.Players;
using MonopolyTests.Fakes;
using NUnit.Framework;

namespace MonopolyTests.GameTests
{
    [TestFixture]
    public class GameTests
    {

        [Test]
        public void TestCreateGameWithTwoPlayersHorseAndCar()
        {
            var players = new [] { new Player(0, "Horse"), new Player(1, "Car") };
            var playerRepository = new PlayerRepository(players);
            var fakeBoard = new FakeBoard(new FakeDice(), playerRepository, new FakeJailRoster());
            var game = new Game(fakeBoard);
            var gamePlayers = fakeBoard.GetPlayers();

            Assert.That(gamePlayers.Count(), Is.EqualTo(2));
            Assert.That(gamePlayers.Any(p => p == 0), Is.True);
            Assert.That(gamePlayers.Any(p => p == 1), Is.True);
        }
    }
}
