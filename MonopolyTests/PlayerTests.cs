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
        public void TestPlayerOn0Rolls7AndMovesTo7()
        {
            player.TakeTurn(7);
            Assert.That(player.Location, Is.EqualTo(7));
        }

        [Test]
        public void TestPlayerOn39Rolls6AndEndsUpOn5()
        {
            player.TakeTurn(39);
            player.TakeTurn(6);
            Assert.That(player.Location, Is.EqualTo(5));
        }
    }
}
