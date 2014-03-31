using Monopoly.Banker;
using Monopoly.JailRoster;
using Monopoly.Locations.Factories;
using Monopoly.Locations.Managers;
using MonopolyTests.Fakes;
using NUnit.Framework;

namespace MonopolyTests.LocationTests.ManagersTests
{
    [TestFixture]
    public class LocationManagerTests
    {
        private LocationManager locationManager;

        [SetUp]
        public void SetUp()
        {
            locationManager = new LocationManager();
            var banker = new TraditionalBanker(new[] {0});
            var locationFactory = new TraditionalLocationFactory(banker, new FakeDice(), new TraditionalJailRoster(banker), locationManager);
            locationManager.SetLocations(locationFactory.GetLocations());
        }

        [Test]
        public void TestPlayerInitializesOnZero()
        {
            Assert.That(locationManager.GetLocationIndexFor(0), Is.EqualTo(0));
        }

        [Test]
        public void TestLocationIndexSetsPlayersLocationProperly()
        {
            locationManager.SetLocationIndexFor(0, 10);

            Assert.That(locationManager.GetLocationIndexFor(0), Is.EqualTo(10));
        }
    }
}
