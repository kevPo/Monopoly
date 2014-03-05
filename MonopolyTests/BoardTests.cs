using Monopoly;
using NUnit.Framework;

namespace MonopolyTests
{
    [TestFixture]
    public class BoardTests
    {
        private Board board;
        private Player player;

        [SetUp]
        public void SetUp()
        {
            board = new Board();
            player = new Player("horse", 0);
            player.LandedOn(board.GetStartingLocation());
        }

        [Test]
        public void TestGetStartingPositionReturnsGo()
        {
            var start = board.GetStartingLocation();
            Assert.That(start.Name, Is.EqualTo("Go"));
        }

        [Test]
        public void TestPlayerOn0Rolls7AndMovesTo7()
        {
            board.MovePlayer(player, 7);
            Assert.That(player.Location.Name, Is.EqualTo("Chance"));
        }

        [Test]
        public void TestPlayerOn39Rolls6AndEndsUpOn5()
        {
            board.MovePlayer(player, 39);
            board.MovePlayer(player, 6);
            Assert.That(player.Location.Name, Is.EqualTo("Reading Railroad"));
        }

        [Test]
        public void TestBalanceIncreasesBy200WhenLandingOnGo()
          {
            board.MovePlayer(player, 40);
            Assert.That(player.Balance, Is.EqualTo(200));
        }

        [Test]
        public void TestPlayerPassesGoTwiceWithOneTurnAndBalanceIncreases400()
        {
            board.MovePlayer(player, 80);
            Assert.That(player.Balance, Is.EqualTo(400));
        }

        [Test]
        public void TestBalanceDoesNotIncreaseForNormalLocations()
        {
            board.MovePlayer(player, 5);
            Assert.That(player.Balance , Is.EqualTo(0));
        }

        [Test]
        public void TestBalanceIncreasesAfterPassingGo()
        {
            board.MovePlayer(player, 42);
            Assert.That(player.Balance, Is.EqualTo(200));
        }

        [Test]
        public void TestPassGoToJailButNotStart()
        {
            board.MovePlayer(player, 33);
            Assert.That(player.Location.Name, Is.EqualTo("Community Chest"));
            Assert.That(player.Balance, Is.EqualTo(0));
        }

        [Test]
        public void TestOnGoUpdateLocationWithoutMovingAndBalanceDoesNotChange()
        {
            board.MovePlayer(player, 0);
            Assert.That(player.Balance, Is.EqualTo(0));
        }

        [Test]
        public void TestPlayerLandsOnIncomeTaxAndBalanceDecreases10Percent()
        {
            var horse = new Player("Horse", 1800);
            horse.LandedOn(board.GetStartingLocation());
            board.MovePlayer(horse, 4);
            Assert.That(horse.Balance, Is.EqualTo(1620));
        }

        [Test]
        public void TestPlayerLandsOnIncomeTaxAndBalanceDecreases200()
        {
            var horse = new Player("Horse", 2200);
            horse.LandedOn(board.GetStartingLocation());
            board.MovePlayer(horse, 4);
            Assert.That(horse.Balance, Is.EqualTo(2000));
        }

        [Test]
        public void TestPlayerPassesOverIncomeTaxAndNothingHappens()
        {
            var horse = new Player("Horse", 1800);
            horse.LandedOn(board.GetStartingLocation());
            board.MovePlayer(horse, 7);
            Assert.That(horse.Balance, Is.EqualTo(1800));
        }

        [Test]
        public void TestPlayerPassesOverLuxuryTaxAndBalanceStaysTheSame()
        {
            board.MovePlayer(player, 39);
            Assert.That(player.Balance, Is.EqualTo(0));
        }
    }
}
