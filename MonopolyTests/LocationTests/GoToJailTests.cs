using Monopoly;
using Monopoly.Locations;
using Monopoly.TraditionalMonopoly;
using NUnit.Framework;

namespace MonopolyTests.LocationTests
{
    [TestFixture]
    public class GoToJailTests
    {

        [Test]
        public void TestLandedOnSendsPlayerToJail()
        {
            var player = new Player(0, "Horse", 100);
            var playerRepository = new PlayerRepository(new[] { player });
            var playerService = new PlayerService(playerRepository);
            var jail = new Jail(10, "Jail/ Just Visiting", playerService);
            var jailRoster = new TraditionalJailRoster();
            var goToJail = new GoToJail(30, "Go To Jail", 10, playerService, jailRoster);
            goToJail.LandedOnBy(player.Id);
            Assert.That(player.LocationIndex, Is.EqualTo(10));
            Assert.That(player.Balance, Is.EqualTo(100));
            Assert.That(jailRoster.IsInJail(player.Id), Is.True);
        }
    }
}
