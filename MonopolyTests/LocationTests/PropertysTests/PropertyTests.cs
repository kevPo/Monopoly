using Monopoly;
using MonopolyTests.Fakes;
using NUnit.Framework;

namespace MonopolyTests.LocationTests.PropertysTests
{
    [TestFixture]
    public class PropertyTests
    {
        private IPlayer car;
        private IPlayer horse;
        private FakeProperty mediterranean;
        private FakeProperty baltic;

        [SetUp]
        public void SetUp()
        {
            car = new Player(0, "car", 2000);
            horse = new Player(1, "horse", 2000);
            var playerRepository = new PlayerRepository(new[] { car, horse });

            mediterranean = new FakeProperty(1, "Mediterranean Avenue", 60, 2, playerRepository);
            baltic = new FakeProperty(3, "Baltic Avenue", 60, 4, playerRepository);
        }

        [Test]
        public void TestPlayerLandsOnUnownedPropertyAndBuysIt()
        {
            mediterranean.LandedOnBy(car.Id);
            Assert.That(car.Balance, Is.EqualTo(1940));
            Assert.That(mediterranean.GetOwner(), Is.EqualTo(car.Id));
        }

        [Test]
        public void TestLandOnPlayerLandsOnOwnedPropertyAndNothingHappens()
        {
            mediterranean.LandedOnBy(car.Id);
            mediterranean.LandedOnBy(car.Id);
            Assert.That(car.Balance, Is.EqualTo(1940));
            Assert.That(mediterranean.GetOwner(), Is.EqualTo(car.Id));
        }

        [Test]
        public void PassingOverUnownedPropertyShouldDoNothing()
        {
            baltic.PassedOverBy(car.Id);
            Assert.That(car.Balance, Is.EqualTo(2000));
        }
    }
}
