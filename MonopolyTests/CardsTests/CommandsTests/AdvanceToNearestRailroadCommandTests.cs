using Monopoly.Cards.Commands;
using NUnit.Framework;

namespace MonopolyTests.CardsTests.CommandsTests
{
    [TestFixture]
    public class AdvanceToNearestRailroadCommandTests : CommandTests
    {
        private AdvanceToNearestRailroadCommand advanceToNearestRailroad;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            advanceToNearestRailroad = new AdvanceToNearestRailroadCommand(banker, gameBoard);
        }

        [Test]
        public void TestAdvanceToNearestRailroadFromGoPlacesPlayerOnLocationFive()
        {
            gameBoard.SetLocationIndexFor(playerOneId, 0);
            advanceToNearestRailroad.PerformOn(playerOneId);

            Assert.That(gameBoard.GetLocationIndexFor(playerOneId), Is.EqualTo(5));
            Assert.That(banker.GetBalanceFor(playerOneId), Is.EqualTo(1300));
        }

        [Test]
        public void TestAdvanceWhenNearestRailroadIsOwnedByAnotherPlayer()
        {
            gameBoard.SetLocationIndexFor(playerOneId, 0);
            gameBoard.SetLocationIndexFor(playerTwoId, 0);
            advanceToNearestRailroad.PerformOn(playerOneId);
            advanceToNearestRailroad.PerformOn(playerTwoId);

            Assert.That(gameBoard.GetLocationIndexFor(playerTwoId), Is.EqualTo(5));
            Assert.That(banker.GetBalanceFor(playerTwoId), Is.EqualTo(1450));
        }
    }
}
