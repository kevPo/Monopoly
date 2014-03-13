using System.Collections.Generic;
using Monopoly;
using Monopoly.Locations;
using Monopoly.PropertyGroups.RentCalculators;
using MonopolyTests.Fakes;
using NUnit.Framework;

namespace MonopolyTests.PropertyGroupsTests.RentCalculatorsTests
{
    [TestFixture]
    public class StreetRentCalculatorTests
    {
        private IPlayer car;
        private Property baltic;
        private Property mediterranean;
        private IEnumerable<Property> properties;
        private RentCalculator rentCalculator;

        [SetUp]
        public void SetUp()
        {
            car = new Player("car", 2000);
            var banker = new FakeBanker();
            mediterranean = new Property(1, "Mediterranean Avenue", 60, 2, banker);
            baltic = new Property(3, "Baltic Avenue", 60, 4, banker);
            properties = new Property[] { mediterranean, baltic };
            rentCalculator = new StreetRentCalculator();
        }

        [Test]
        public void TestPlayerPaysRentValueWhenNotAllInGroupAreOwned()
        {
            baltic.LandedOnBy(car);
            var rent = rentCalculator.CalculateRentFor(baltic, properties);
            Assert.That(rent, Is.EqualTo(baltic.Rent));
        }

        [Test]
        public void TestPlayerPaysTwiceTheRentValueWhenOwnerOwnsGroup()
        {
            baltic.LandedOnBy(car);
            mediterranean.LandedOnBy(car);
            var rent = rentCalculator.CalculateRentFor(baltic, properties);
            Assert.That(rent, Is.EqualTo(baltic.Rent * 2));
        }
    }
}
