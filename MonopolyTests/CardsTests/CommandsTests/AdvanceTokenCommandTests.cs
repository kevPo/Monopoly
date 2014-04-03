using Monopoly.Cards.Commands;
using NUnit.Framework;

namespace MonopolyTests.CardsTests.CommandsTests
{
    [TestFixture]
    public class AdvanceTokenCommandTests : CommandTests
    {
        [Test]
        public void TestMovementCommandMovesPlayerToNewLocation()
        {
            var movementCommand = new AdvanceTokenCommand(5, gameBoard);

            movementCommand.PerformOn(0);

            Assert.That(gameBoard.GetLocationIndexFor(0), Is.EqualTo(5));
            Assert.That(banker.GetBalanceFor(0), Is.EqualTo(1300));
        }
    }
}
