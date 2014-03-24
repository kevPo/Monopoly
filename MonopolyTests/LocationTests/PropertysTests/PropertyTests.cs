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
            car = new Player("car", 2000);
            horse = new Player("horse", 2000);

            mediterranean = new FakeProperty(1, "Mediterranean Avenue", 60, 2);
            baltic = new FakeProperty(3, "Baltic Avenue", 60, 4);
        }

        [Test]
        public void TestPlayerLandsOnUnownedPropertyAndBuysIt()
        {
            mediterranean.LandedOnBy(car);
            Assert.That(car.Balance, Is.EqualTo(1940));
            Assert.That(mediterranean.GetOwner(), Is.EqualTo(car));
        }

        [Test]
        public void TestLandOnPlayerLandsOnOwnedPropertyAndNothingHappens()
        {
            mediterranean.LandedOnBy(car);
            mediterranean.LandedOnBy(car);
            Assert.That(car.Balance, Is.EqualTo(1940));
            Assert.That(mediterranean.GetOwner(), Is.EqualTo(car));
        }

        [Test]
        public void PassingOverUnownedPropertyShouldDoNothing()
        {
            baltic.PassedOverBy(car);
            Assert.That(car.Balance, Is.EqualTo(2000));
        }
    }
}
