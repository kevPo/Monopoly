using Monopoly.Cards.Commands;
using NUnit.Framework;

namespace MonopolyTests.CardsTests.CommandsTests
{
    [TestFixture]
    public class PayEachPlayerCommandTests : CommandTests
    {
        [Test]
        public void TestPayEachPlayer50PaysAllOthers50()
        {
            var command = new PayEachPlayerCommand(banker, 50);
            command.PerformOn(playerOneId);

            Assert.That(banker.GetBalanceFor(playerOneId), Is.EqualTo(1300));
            Assert.That(banker.GetBalanceFor(playerTwoId), Is.EqualTo(1550));
            Assert.That(banker.GetBalanceFor(playerThreeId), Is.EqualTo(1550));
            Assert.That(banker.GetBalanceFor(playerFourId), Is.EqualTo(1550));
            Assert.That(banker.GetBalanceFor(playerFiveId), Is.EqualTo(1550));
        }
    }
}
