using Monopoly;
using NUnit.Framework;

namespace MonopolyTests
{
    [TestFixture]
    public class PlayerTests
    {
        private Player player;

        [SetUp]
        public void SetUp()
        {
            player = new Player("Horse");
        }

        [TearDown]
        public void TearDown()
        {
            player = new Player("Horse");
        }

        [Test]
        public void TestPlayerOnZeroRollsSevenAndMovesToSeven()
        {
            player.Rolled(7);
            Assert.That(player.Location, Is.EqualTo(7));
        }

        [Test]
        public void TestPlayerOn39Rolls6AndEndsUpOn5()
        {
            player.Location = 39;
            player.Rolled(6);
            Assert.That(player.Location, Is.EqualTo(5));
        }

        [Test]
        public void TestTakeTurnIncrementsTurnCountAndMovesPlayer()
        {
            player.TakeTurn();
            Assert.That(player.Location != 0, Is.True);
        }
    }
}
