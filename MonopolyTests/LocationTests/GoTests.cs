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
            starter = new Go(0, "Go");
            player = new Player("horse", 1800);
        }

        [Test]
        public void TestPlayerReceivesSalaryOf200WhenLandingOnStarter()
        {
            starter.LandedOnBy(player);
            Assert.That(player.Balance, Is.EqualTo(2000));
        }

        [Test]
        public void TestPlayerReceivesSalaryOf200WhenPassedOver()
        {
            starter.PassedOverBy(player);
            Assert.That(player.Balance, Is.EqualTo(2000));
        }
    }
}
