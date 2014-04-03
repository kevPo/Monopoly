using Monopoly.Cards.Commands;
using NUnit.Framework;

namespace MonopolyTests.CardsTests.CommandsTests
{
    [TestFixture]
    public class CollectMoneyFromAllPlayersCommandTests : CommandTests
    {
        [Test]
        public void TestCollect50FromAllPlayersGivesPlayer200ForGameOfFive()
        {
            var command = new CollectMoneyFromAllPlayersCommand(banker, 50);
            command.PerformOn(playerOneId);

            Assert.That(banker.GetBalanceFor(playerOneId), Is.EqualTo(1700));
            Assert.That(banker.GetBalanceFor(playerTwoId), Is.EqualTo(1450));
            Assert.That(banker.GetBalanceFor(playerThreeId), Is.EqualTo(1450));
            Assert.That(banker.GetBalanceFor(playerFourId), Is.EqualTo(1450));
            Assert.That(banker.GetBalanceFor(playerFiveId), Is.EqualTo(1450));
        }
    }
}
