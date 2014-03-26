using System.Collections.Generic;
using Monopoly;
using Monopoly.Locations.Propertys;
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

        [SetUp]
        public void SetUp()
        {
            car = new Player(0, "car", 2000);
            horse = new Player(1, "horse", 2000);
            var playerRepository = new PlayerRepository(new[] { car, horse });
            var playerService = new PlayerService(playerRepository);
            var purpleStreets = new List<Street>();
            mediterranean = new Street(1, "Mediterranean Avenue", 60, 2, playerService, purpleStreets);
            baltic = new Street(3, "Baltic Avenue", 60, 4, playerService, purpleStreets);

            purpleStreets.AddRange(new Street[] { mediterranean, baltic });
        }

        [Test]
        public void TestPlayerPaysRentValueWhenNotAllInGroupAreOwned()
        {
            baltic.LandedOnBy(car.Id);

            baltic.LandedOnBy(horse.Id);
            Assert.That(horse.Balance, Is.EqualTo(1996));
        }

        [Test]
        public void TestPlayerPaysTwiceTheRentValueWhenOwnerOwnsGroup()
        {
            baltic.LandedOnBy(car.Id);
            mediterranean.LandedOnBy(car.Id);

            baltic.LandedOnBy(horse.Id);
            Assert.That(horse.Balance, Is.EqualTo(1992));
        }
    }
}
