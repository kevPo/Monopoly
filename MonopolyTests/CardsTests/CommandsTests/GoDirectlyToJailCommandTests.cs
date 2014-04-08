using Monopoly.Cards.Commands;
using NUnit.Framework;

namespace MonopolyTests.CardsTests.CommandsTests
{
    [TestFixture]
    public class GoDirectlyToJailCommandTests : CommandTests
    {
        [Test]
        public void TestGoDirectlyToJailCommandSendsPlayerToJail()
        {
            gameBoard.SendPlayerDirectlyTo(playerOneId, 20);
            var command = new GoDirectlyToJailCommand(jailRoster, gameBoard);
            command.PerformOn(playerOneId);

            Assert.That(gameBoard.GetLocationIndexFor(playerOneId), Is.EqualTo(10));
            Assert.That(jailRoster.IsInJail(playerOneId), Is.True);
            Assert.That(banker.GetBalanceFor(playerOneId), Is.EqualTo(1500));
        }
    }
}
