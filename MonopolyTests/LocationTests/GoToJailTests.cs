using Monopoly;
using Monopoly.Locations;
using NUnit.Framework;

namespace MonopolyTests.LocationTests
{
    [TestFixture]
    public class GoToJailTests
    {

        [Test]
        public void TestLandedOnSendsPlayerToJail()
        {
            var player = new Player("Horse", 100);
            var goToJail = new GoToJail(new Jail());
            goToJail.LandedOnBy(player);
            Assert.That(player.Location.Name, Is.EqualTo("Jail/ Just Visiting"));
            Assert.That(player.Balance, Is.EqualTo(100));
        }
    }
}
