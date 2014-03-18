using System.Collections.Generic;
using Monopoly;
using Monopoly.Locations.Propertys;
using Monopoly.TraditionalMonopoly;
using NUnit.Framework;

namespace MonopolyTests.LocationTests.PropertysTests
{
    [TestFixture]
    public class PropertyTests
    {
        private IPlayer car;
        private IPlayer horse;
        private Property mediterranean;
        private Property baltic;
        private IBanker banker;

        [SetUp]
        public void SetUp()
        {
            car = new Player("car", 2000);
            horse = new Player("horse", 2000);
            var titleDeeds = new List<TitleDeed>();
            var propertyManager = new PropertyManager();
            banker = new TraditionalBanker(titleDeeds, propertyManager);


            mediterranean = new Street(1, "Mediterranean Avenue", banker, propertyManager);
            baltic = new Street(3, "Baltic Avenue", banker, propertyManager);

            titleDeeds.Add(new TitleDeed(mediterranean, 60, 2, PropertyGroup.Purple));
            titleDeeds.Add(new TitleDeed(baltic, 60, 4, PropertyGroup.Purple));
        }

        [Test]
        public void TestPlayerLandsOnUnownedPropertyAndBuysIt()
        {
            mediterranean.LandedOnBy(car);
            Assert.That(car.Balance, Is.EqualTo(1940));
        }

        [Test]
        public void TestLandOnPlayerLandsOnOwnedPropertyAndNothingHappens()
        {
            mediterranean.LandedOnBy(car);
            mediterranean.LandedOnBy(car);
            Assert.That(car.Balance, Is.EqualTo(1940));
        }

        [Test]
        public void PassingOverUnownedPropertyShouldDoNothing()
        {
            baltic.PassedOverBy(car);
            Assert.That(car.Balance, Is.EqualTo(2000));
        }
    }
}
