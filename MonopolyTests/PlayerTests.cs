using Monopoly;
using NUnit.Framework;

namespace MonopolyTests
{
    [TestFixture]
    public class PlayerTests
    {
        private Player player;
        private Board board;

        [SetUp]
        public void SetUp()
        {
            board = new Board();
            player = new Player("Horse", board);
        }

        [TearDown]
        public void TearDown()
        {
            player = new Player("Horse", board);
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
    }
}
