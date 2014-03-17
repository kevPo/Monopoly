using System.Collections.Generic;
using Monopoly;
using Monopoly.Locations;
using Monopoly.PropertyGroups.RentCalculators;
using MonopolyTests.Fakes;
using NUnit.Framework;

namespace MonopolyTests.PropertyGroupsTests.RentCalculatorsTests
{
    [TestFixture]
    public class UtilityRentCalculatorTests
    {
        private IPlayer car;
        private Property electric;
        private Property waterWorks;
        private IEnumerable<Property> properties;
        private RentCalculator rentCalculator;
        private FakeDice dice;

        [SetUp]
        public void SetUp()
        {
            car = new Player("car", 2000);
            var banker = new FakeBanker();
            electric = new Property(12, "Electric Company", 150, 0, banker);
            waterWorks = new Property(28, "Water Works", 150, 0, banker);
            properties = new Property[] { electric, waterWorks };
            dice = new FakeDice();
            dice.NextRoll = 10;
            rentCalculator = new UtilityRentCalculator(dice);
        }

        [Test]
        public void TestUtilityRentWhenOneIsOwnedIss4TimesDiceRoll()
        {
            electric.LandedOnBy(car);
            var rent = rentCalculator.CalculateRentFor(electric, properties);
            Assert.That(rent, Is.EqualTo(dice.GetCurrentRoll() * 4));
        }

        [Test]
        public void TestUtilityRentWhenBothAreOwnedIs10TimeDiceRoll()
        {
            waterWorks.LandedOnBy(car);
            electric.LandedOnBy(car);
            var rent = rentCalculator.CalculateRentFor(electric, properties);
            Assert.That(rent, Is.EqualTo(dice.GetCurrentRoll() * 10));
        }
    }
}
