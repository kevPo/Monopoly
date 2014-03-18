using System.Collections.Generic;
using Monopoly;
using Monopoly.Locations.Propertys;
using Monopoly.TraditionalMonopoly;
using NUnit.Framework;

namespace MonopolyTests.LocationTests.PropertysTests
{
    [TestFixture]
    public class StreetTests
    {
        private IPlayer car;
        private IPlayer horse;
        private Property baltic;
        private Property mediterranean;

        [SetUp]
        public void SetUp()
        {
            car = new Player("car", 2000);
            horse = new Player("horse", 2000);
            var titleDeeds = new List<TitleDeed>();
            var propertyManager = new PropertyManager();
            var banker = new TraditionalBanker(titleDeeds, propertyManager);


            mediterranean = new Street(1, "Mediterranean Avenue", banker, propertyManager);
            baltic = new Street(3, "Baltic Avenue", banker, propertyManager);

            titleDeeds.Add(new TitleDeed(mediterranean, 60, 2, PropertyGroup.Purple));
            titleDeeds.Add(new TitleDeed(baltic, 60, 4, PropertyGroup.Purple));
        }

        [Test]
        public void TestPlayerPaysRentValueWhenNotAllInGroupAreOwned()
        {
            baltic.LandedOnBy(car);

            baltic.LandedOnBy(horse);
            Assert.That(horse.Balance, Is.EqualTo(1996));
        }

        [Test]
        public void TestPlayerPaysTwiceTheRentValueWhenOwnerOwnsGroup()
        {
            baltic.LandedOnBy(car);
            mediterranean.LandedOnBy(car);

            baltic.LandedOnBy(horse);
            Assert.That(horse.Balance, Is.EqualTo(1992));
        }
    }
}
