using System.Collections.Generic;
using Monopoly.Banker;
using Monopoly.Dice;
using Monopoly.Locations.Propertys;
using Monopoly.Players;
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
        private IDice dice;
        private IBanker banker;

        [SetUp]
        public void SetUp()
        {
            car = new Player(0, "Car");
            horse = new Player(1, "Horse");
            dice = new FakeDice(new [] { new FakeRoll(7, 3) });
            banker = new TraditionalBanker(new [] { car.Id, horse.Id });
            var utilities = new List<Utility>();
            electric = new Utility(12, "Electric Company", 150, 0, banker, utilities, dice);
            waterWorks = new Utility(28, "Water Works", 150, 0, banker, utilities, dice);
            utilities.AddRange(new Utility[] { electric, waterWorks });
        }

        [Test]
        public void TestUtilityRentWhenOneIsOwnedIs4TimesDiceRoll()
        {
            electric.LandedOnBy(car.Id);

            dice.Roll();
            electric.LandedOnBy(horse.Id);

            Assert.That(banker.GetBalanceFor(horse.Id), Is.EqualTo(1460));
            Assert.That(banker.GetBalanceFor(car.Id), Is.EqualTo(1390));
        }

        [Test]
        public void TestUtilityRentWhenBothAreOwnedIs10TimeDiceRoll()
        {
            waterWorks.LandedOnBy(car.Id);
            electric.LandedOnBy(car.Id);

            dice.Roll();
            electric.LandedOnBy(horse.Id);

            Assert.That(banker.GetBalanceFor(horse.Id), Is.EqualTo(1400));
            Assert.That(banker.GetBalanceFor(car.Id), Is.EqualTo(1300));
        }
    }
}
