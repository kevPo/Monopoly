using Monopoly;
using Monopoly.Locations;
using NUnit.Framework;

namespace MonopolyTests.LocationTests
{
    [TestFixture]
    public class GoTests
    {
        private Go starter;
        private IPlayer player;

        [SetUp]
        public void SetUp()
        {
            player = new Player(0, "horse", 1800);
            var playerRepository = new PlayerRepository(new []{ player });
            var playerService = new PlayerService(playerRepository);
            starter = new Go(0, "Go", playerService);
        }

        [Test]
        public void TestPlayerReceivesSalaryOf200WhenLandingOnStarter()
        {
            starter.LandedOnBy(player.Id);
            Assert.That(player.Balance, Is.EqualTo(2000));
        }

        [Test]
        public void TestPlayerReceivesSalaryOf200WhenPassedOver()
        {
            starter.PassedOverBy(player.Id);
            Assert.That(player.Balance, Is.EqualTo(2000));
        }
    }
}
