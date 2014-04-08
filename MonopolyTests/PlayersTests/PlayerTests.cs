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

        [Test]
        public void TestHorseDoesNotEqualString()
        {
            Assert.That(player.Equals("player"), Is.False);
        }

        [Test]
        public void TestGetHashcode()
        {
            var code = (player.Token.GetHashCode() ^ 2) + (player.Id.GetHashCode() ^ 2) * 17;
            Assert.That(player.GetHashCode(), Is.EqualTo(code));
        }
    }
}
