using Monopoly.Banker;
using Monopoly.Cards.Commands;
using NUnit.Framework;

namespace MonopolyTests.CardsTests.CommandsTests
{
    [TestFixture]
    public class GiveMoneyCommandTests
    {
        [Test]
        public void TestCollect50Adds50ToPlayersBalance()
        {
            var playerId = 0;
            var banker = new TraditionalBanker(new[] { playerId });
            var collectMoneyCommand = new CollectMoneyCommand(banker, 50);
            collectMoneyCommand.PerformOn(playerId);

            Assert.That(banker.GetBalanceFor(playerId), Is.EqualTo(1550));
        }
    }
}
