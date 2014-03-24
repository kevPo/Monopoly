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
            var jail = new Jail(10, "Jail/ Just Visiting");
            var jailRoster = new JailRoster();
            var goToJail = new GoToJail(30, "Go To Jail", 10, jailRoster);
            goToJail.LandedOnBy(player);
            Assert.That(player.LocationIndex, Is.EqualTo(10));
            Assert.That(player.Balance, Is.EqualTo(100));
            Assert.That(jailRoster.IsInJail(player), Is.True);
        }
    }
}
