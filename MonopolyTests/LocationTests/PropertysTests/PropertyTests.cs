using System.Collections.Generic;
using Monopoly;
using Monopoly.Locations.Propertys;
using NUnit.Framework;

namespace MonopolyTests.LocationTests.PropertysTests
{
    [TestFixture]
    public class PropertyTests
    {
        private IPlayer car;
        private IPlayer horse;
        private Street mediterranean;
        private Street baltic;

        [SetUp]
        public void SetUp()
        {
            car = new Player("car", 2000);
            horse = new Player("horse", 2000);

            var yellowStreets = new List<Street>();
            mediterranean = new Street(1, "Mediterranean Avenue", 60, 2, yellowStreets);
            baltic = new Street(3, "Baltic Avenue", 60, 4, yellowStreets);

            yellowStreets.AddRange(new Street[] { mediterranean, baltic });
        }

        [Test]
        public void TestPlayerLandsOnUnownedPropertyAndBuysIt()
        {
            mediterranean.LandedOnBy(car);
            Assert.That(car.Balance, Is.EqualTo(1940));
            Assert.That(mediterranean.Owner, Is.EqualTo(car));
        }

        [Test]
        public void TestLandOnPlayerLandsOnOwnedPropertyAndNothingHappens()
        {
            mediterranean.LandedOnBy(car);
            mediterranean.LandedOnBy(car);
            Assert.That(car.Balance, Is.EqualTo(1940));
            Assert.That(mediterranean.Owner, Is.EqualTo(car));
        }

        [Test]
        public void PassingOverUnownedPropertyShouldDoNothing()
        {
            baltic.PassedOverBy(car);
            Assert.That(car.Balance, Is.EqualTo(2000));
        }
    }
}
