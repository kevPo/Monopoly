using System.Collections.Generic;
using Monopoly;
using Monopoly.Locations.Propertys;
using Monopoly.TraditionalMonopoly;
using MonopolyTests.Fakes;
using NUnit.Framework;

namespace MonopolyTests.LocationTests.PropertysTests
{
    [TestFixture]
    public class UtilityTests
    {
        private IPlayer car;
        private IPlayer horse;
        private Property electric;
        private Property waterWorks;
        private FakeDice dice;

        [SetUp]
        public void SetUp()
        {
            car = new Player("car", 2000);
            horse = new Player("horse", 2000);
            dice = new FakeDice();
            dice.NextRoll = 10;
            var titleDeeds = new List<TitleDeed>();
            var propertyManager = new PropertyManager();
            var banker = new TraditionalBanker(titleDeeds, propertyManager);

            electric = new Utility(12, "Electric Company", banker, propertyManager, dice);
            waterWorks = new Utility(28, "Water Works", banker, propertyManager, dice);

            titleDeeds.Add(new TitleDeed(electric, 150, 0, PropertyGroup.Utility));
            titleDeeds.Add(new TitleDeed(waterWorks, 150, 0, PropertyGroup.Utility));
        }

        [Test]
        public void TestUtilityRentWhenOneIsOwnedIss4TimesDiceRoll()
        {
            electric.LandedOnBy(car);

            electric.LandedOnBy(horse);
            Assert.That(horse.Balance, Is.EqualTo(1960));
        }

        [Test]
        public void TestUtilityRentWhenBothAreOwnedIs10TimeDiceRoll()
        {
            waterWorks.LandedOnBy(car);
            electric.LandedOnBy(car);

            electric.LandedOnBy(horse);
            Assert.That(horse.Balance, Is.EqualTo(1900));
        }
    }
}
