using Monopoly.Players;
using NUnit.Framework;

namespace MonopolyTests.PlayersTests
{
    [TestFixture]
    public class PlayerTests
    {
        private Player player;

        [SetUp]
        public void SetUp()
        {
            player = new Player(0, "Horse");
        }

        [Test]
        public void TestHorsePlayerDoesNotEqualCarPlayer()
        {
            var car = new Player(0, "Car");
            Assert.That(player.Equals(car), Is.False);
        }

        [Test]
        public void TestHorsePlayerEqualsItself()
        {
            Assert.That(player.Equals(player), Is.True);
        }
    }
}
