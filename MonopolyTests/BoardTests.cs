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
            player = new Player("horse", 0, board);
        }

        [TearDown]
        public void TearDown()
        {
            player = new Player("horse", 0, board);
        }

        [Test]
        public void TestGetStartingPositionReturnsGo()
        {
            var start = board.GetStartingLocation();
            Assert.That(start.Name, Is.EqualTo("Go"));
        }

        [Test]
        public void TestBalanceIncreasesBy200WhenLandingOnGo()
          {
            board.MovePlayer(player, 40);
            Assert.That(player.Balance, Is.EqualTo(200));
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
            var horse = new Player("horse", 0, board);
            horse.TakeTurn(37);
            board.MovePlayer(horse, 5);
            Assert.That(horse.Balance, Is.EqualTo(200));
        }

        [Test]
        public void TestOnGoUpdateLocationWithoutMovingAndBalanceDoesNotChange()
        {
            board.MovePlayer(player, 0);
            Assert.That(player.Balance, Is.EqualTo(0));
        }
    }
}
