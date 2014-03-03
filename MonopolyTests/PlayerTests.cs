using Monopoly;
using NUnit.Framework;

namespace MonopolyTests
{
    [TestFixture]
    public class PlayerTests
    {
        private Player player;
        private GameMediator gameMediator;

        [SetUp]
        public void SetUp()
        {
            gameMediator = new GameMediator(new Board(), new LocationAssessor());
            player = new Player("Horse", 0, gameMediator);
        }

        [TearDown]
        public void TearDown()
        {
            player = new Player("Horse", 0, gameMediator);
        }

        [Test]
        public void TestPlayerOn0Rolls7AndMovesTo7()
        {
            player.TakeTurn(7);
            Assert.That(player.Location, Is.EqualTo("Chance"));
        }

        [Test]
        public void TestPlayerOn39Rolls6AndEndsUpOn5()
        {
            player.TakeTurn(39);
            player.TakeTurn(6);
            Assert.That(player.Location, Is.EqualTo("Reading Railroad"));
        }

        [Test]
        public void TestPlayerPassesGoTwiceWithOneTurnAndBalanceIncreases400()
        {
            player.TakeTurn(85);
            Assert.That(player.Balance, Is.EqualTo(400));
        }

        [Test]
        public void TestPassGoToJailButNotStart()
        {
            player.TakeTurn(33);
            Assert.That(player.Location, Is.EqualTo("Community Chest"));
            Assert.That(player.Balance, Is.EqualTo(0));
        }

        [Test]
        public void TestPlayerLandsOnIncomeTaxAndBalanceDecreases10Percent()
        {
            var horse = new Player("Horse", 1800, gameMediator);
            horse.TakeTurn(4);
            Assert.That(horse.Balance, Is.EqualTo(1620));
        }

        [Test]
        public void TestPlayerLandsOnIncomeTaxAndBalanceDecreases200()
        {
            var horse = new Player("Horse", 2200, gameMediator);
            horse.TakeTurn(4);
            Assert.That(horse.Balance, Is.EqualTo(2000));
        }

        [Test]
        public void TestPlayerPassesOverIncomeTaxAndNothingHappens()
        {
            var horse = new Player("Horse", 1800, gameMediator);
            horse.TakeTurn(5);
            Assert.That(horse.Balance, Is.EqualTo(1800));
        }

        [Test]
        public void TestPlayerPassesOverLuxuryTaxAndBalanceStaysTheSame()
        {
            player.TakeTurn(39);
            Assert.That(player.Balance, Is.EqualTo(0));
        }
    }
}
