using System.Collections.Generic;
using Monopoly.Banker;
using Monopoly.Locations.Propertys;
using Monopoly.Players;
using NUnit.Framework;

namespace MonopolyTests.LocationTests.PropertysTests
{
    [TestFixture]
    public class StreetTests
    {
        private IPlayer car;
        private IPlayer horse;
        private Street baltic;
        private Street mediterranean;
        private IBanker banker;

        [SetUp]
        public void SetUp()
        {
            car = new Player(0, "car");
            horse = new Player(1, "horse");
            banker = new TraditionalBanker(new [] { car.Id, horse.Id });
            var purpleStreets = new List<Street>();
            mediterranean = new Street(1, "Mediterranean Avenue", 60, 2, banker, purpleStreets);
            baltic = new Street(3, "Baltic Avenue", 60, 4, banker, purpleStreets);

            purpleStreets.AddRange(new Street[] { mediterranean, baltic });
        }

        [Test]
        public void TestPlayerPaysRentValueWhenNotAllInGroupAreOwned()
        {
            baltic.LandedOnBy(car.Id);

            baltic.LandedOnBy(horse.Id);
            Assert.That(banker.GetBalanceFor(horse.Id), Is.EqualTo(1496));
        }

        [Test]
        public void TestPlayerPaysTwiceTheRentValueWhenOwnerOwnsGroup()
        {
            baltic.LandedOnBy(car.Id);
            mediterranean.LandedOnBy(car.Id);

            baltic.LandedOnBy(horse.Id);
            Assert.That(banker.GetBalanceFor(horse.Id), Is.EqualTo(1492));
        }
    }
}
