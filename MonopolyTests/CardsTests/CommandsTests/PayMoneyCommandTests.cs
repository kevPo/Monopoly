using Monopoly.Banker;
using Monopoly.Cards.Commands;
using NUnit.Framework;

namespace MonopolyTests.CardsTests.CommandsTests
{
    [TestFixture]
    public class PayMoneyCommandTests
    {
        [Test]
        public void TestPayMoneyCommandFor100MakesPlayerPay100ToBank()
        {
            var playerId = 0;
            var banker = new TraditionalBanker(new[] { playerId });
            var payMoneyCommand = new PayMoneyCommand(banker, 100);

            payMoneyCommand.PerformOn(playerId);

            Assert.That(banker.GetBalanceFor(playerId), Is.EqualTo(1400));
        }
    }
}
