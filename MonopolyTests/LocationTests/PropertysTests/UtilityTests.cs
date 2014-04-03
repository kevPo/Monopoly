using System;
using System.Collections.Generic;
using Monopoly.Banker;
using Monopoly.Dice;
using Monopoly.Locations.Propertys;
using MonopolyTests.Fakes;
using NUnit.Framework;

namespace MonopolyTests.LocationTests.PropertysTests
{
    [TestFixture]
    public class UtilityTests
    {
        private Int32 playerOneId;
        private Int32 playerTwoId;
        private Utility electric;
        private Utility waterWorks;
        private IDice dice;
        private IBanker banker;

        [SetUp]
        public void SetUp()
        {
            playerOneId = 0;
            playerTwoId = 1;
            dice = new FakeDice(new [] { new FakeRoll(7, 3) });
            banker = new TraditionalBanker(new [] { playerOneId, playerTwoId });
            var utilities = new List<Utility>();
            electric = new Utility(12, "Electric Company", 150, 0, banker, utilities, dice);
            waterWorks = new Utility(28, "Water Works", 150, 0, banker, utilities, dice);
            utilities.AddRange(new Utility[] { electric, waterWorks });
        }

        [Test]
        public void TestUtilityRentWhenOneIsOwnedIs4TimesDiceRoll()
        {
            electric.LandedOnBy(playerOneId);

            dice.Roll();
            electric.LandedOnBy(playerTwoId);

            Assert.That(banker.GetBalanceFor(playerTwoId), Is.EqualTo(1460));
            Assert.That(banker.GetBalanceFor(playerOneId), Is.EqualTo(1390));
        }

        [Test]
        public void TestUtilityRentWhenBothAreOwnedIs10TimeDiceRoll()
        {
            waterWorks.LandedOnBy(playerOneId);
            electric.LandedOnBy(playerOneId);

            dice.Roll();
            electric.LandedOnBy(playerTwoId);

            Assert.That(banker.GetBalanceFor(playerTwoId), Is.EqualTo(1400));
            Assert.That(banker.GetBalanceFor(playerOneId), Is.EqualTo(1300));
        }
    }
}
