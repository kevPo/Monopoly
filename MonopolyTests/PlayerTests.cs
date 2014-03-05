using Monopoly;
using Monopoly.Locations;
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
            player = new Player("Horse", 0);
        }

        [Test]
        public void TestPlayerTakeAwayMoneyDecrementsBalanceByGivenAmount()
        {
            var horse = new Player("horse", 200);
            horse.TakeAwayMoney(75);
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
            player.LandedOn(new Property("Boardwalk", 400));
            Assert.That(player.Location.Name, Is.EqualTo("Boardwalk"));
        }
    }
}
