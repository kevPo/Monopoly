using Monopoly.Banker;
using Monopoly.Locations.Defaults;
using Monopoly.Players;
using NUnit.Framework;

namespace MonopolyTests.LocationTests.DefaultsTests
{
    [TestFixture]
    public class GoTests
    {
        private Go starter;
        private IPlayer player;
        private TraditionalBanker banker;

        [SetUp]
        public void SetUp()
        {
            player = new Player(0, "horse");
            banker = new TraditionalBanker(new[] { player.Id });
            starter = new Go(0, "Go", banker);
        }

        [Test]
        public void TestPlayerReceivesSalaryOf200WhenLandingOnStarter()
        {
            starter.LandedOnBy(player.Id);
            Assert.That(banker.GetBalanceFor(player.Id), Is.EqualTo(1700));
        }

        [Test]
        public void TestPlayerReceivesSalaryOf200WhenPassedOver()
        {
            starter.PassedOverBy(player.Id);
            Assert.That(banker.GetBalanceFor(player.Id), Is.EqualTo(1700));
        }
    }
}
