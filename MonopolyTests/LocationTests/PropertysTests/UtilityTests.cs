using System.Collections.Generic;
using Monopoly;
using Monopoly.Locations.Propertys;
using MonopolyTests.Fakes;
using NUnit.Framework;

namespace MonopolyTests.LocationTests.PropertysTests
{
    [TestFixture]
    public class UtilityTests
    {
        private IPlayer car;
        private IPlayer horse;
        private Utility electric;
        private Utility waterWorks;

        [SetUp]
        public void SetUp()
        {
            car = new Player(0, "Car", 2000);
            horse = new Player(1, "Horse", 2000);
            var dice = new FakeDice();
            dice.NextRoll = 10;
            var playerRepository = new PlayerRepository(new IPlayer[] { car, horse });
            var playerService = new PlayerService(playerRepository);
            var utilities = new List<Utility>();
            electric = new Utility(12, "Electric Company", 150, 0, playerService, utilities, dice);
            waterWorks = new Utility(28, "Water Works", 150, 0, playerService, utilities, dice);
            utilities.AddRange(new Utility[] { electric, waterWorks });
        }

        [Test]
        public void TestUtilityRentWhenOneIsOwnedIs4TimesDiceRoll()
        {
            electric.LandedOnBy(car.Id);
            electric.LandedOnBy(horse.Id);

            Assert.That(horse.Balance, Is.EqualTo(1960));
            Assert.That(car.Balance, Is.EqualTo(1890));
        }

        [Test]
        public void TestUtilityRentWhenBothAreOwnedIs10TimeDiceRoll()
        {
            waterWorks.LandedOnBy(car.Id);
            electric.LandedOnBy(car.Id);
            electric.LandedOnBy(horse.Id);

            Assert.That(horse.Balance, Is.EqualTo(1900));
            Assert.That(car.Balance, Is.EqualTo(1800));
        }
    }
}
