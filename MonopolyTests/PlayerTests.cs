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
            player = new Player(0, "Horse", 0);
        }

        [Test]
        public void TestPlayerRemoveMoneyDecrementsBalanceByGivenAmount()
        {
            var horse = new Player(0, "horse", 200);
            horse.RemoveMoney(75);
            Assert.That(horse.Balance, Is.EqualTo(125));
        }

        [Test]
        public void TestPlayerReceivesMoneyIncrementsBalanceByGivenAmount()
        {
            player.ReceiveMoney(30);
            Assert.That(player.Balance, Is.EqualTo(30));
        }

        [Test]
        public void TestLandedOnSetsLocation()
        {
            player.LocationIndex = 0;
            Assert.That(player.LocationIndex, Is.EqualTo(0));
        }

        [Test]
        public void TestHorsePlayerDoesNotEqualCarPlayer()
        {
            var car = new Player(0, "Car", 0);
            Assert.That(player.Equals(car), Is.False);
        }

        [Test]
        public void TestHorsePlayerEqualsItself()
        {
            Assert.That(player.Equals(player), Is.True);
        }
    }
}
