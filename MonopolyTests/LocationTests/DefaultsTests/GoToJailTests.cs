using Monopoly.Banker;
using Monopoly.JailRoster;
using Monopoly.Locations.Defaults;
using Monopoly.Locations.Factories;
using Monopoly.Locations.Managers;
using Monopoly.Players;
using MonopolyTests.Fakes;
using NUnit.Framework;

namespace MonopolyTests.LocationTests.DefaultsTests
{
    [TestFixture]
    public class GoToJailTests
    {
        private Player player;
        private GoToJail goToJail;
        private TraditionalBanker banker;
        private TraditionalJailRoster jailRoster;
        private LocationManager locationManager;

        [SetUp]
        public void SetUp()
        {
            player = new Player(0, "Horse");
            banker = new TraditionalBanker(new[] { player.Id });
            jailRoster = new TraditionalJailRoster(banker);
            locationManager = new LocationManager();
            var locationFactory = new TraditionalLocationFactory(banker, new FakeDice(), jailRoster, locationManager);
            locationManager.SetLocations(locationFactory.GetLocations());
            goToJail = new GoToJail(30, "Go To Jail", 10, banker, jailRoster, locationManager);
            
        }

        [Test]
        public void TestLandedOnSendsPlayerToJail()
        {
            goToJail.LandedOnBy(player.Id);
            
            Assert.That(locationManager.GetLocationIndexFor(player.Id), Is.EqualTo(10));
            Assert.That(banker.GetBalanceFor(0), Is.EqualTo(1500));
            Assert.That(jailRoster.IsInJail(player.Id), Is.True);
        }
    }
}
