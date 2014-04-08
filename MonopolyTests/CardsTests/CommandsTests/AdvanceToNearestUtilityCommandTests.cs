using Monopoly.Cards.Commands;
using MonopolyTests.Fakes;
using NUnit.Framework;

namespace MonopolyTests.CardsTests.CommandsTests
{
    [TestFixture]
    public class AdvanceToNearestUtilityCommandTests : CommandTests
    {
        private AdvanceToNearestUtilityCommand command;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            command = new AdvanceToNearestUtilityCommand(gameBoard);
        }

        [Test]
        public void TestAdvanceToUnownedUtilityAndPlayerBuysIt()
        {
            gameBoard.SendPlayerDirectlyTo(playerOneId, 0);
            command.PerformOn(playerOneId);

            Assert.That(gameBoard.GetLocationIndexFor(0), Is.EqualTo(12));
            Assert.That(banker.GetBalanceFor(0), Is.EqualTo(1350));
        }

        [Test]
        public void TestAdvanceToOwnedUtilityAndPlayerPaysTenTimesDiceRollOf10InRent()
        {
            dice.SetRolls(new[] { new FakeRoll(5, 5) });
            gameBoard.SendPlayerDirectlyTo(playerOneId, 0);
            gameBoard.SendPlayerDirectlyTo(playerTwoId, 0);
            command.PerformOn(playerOneId);
            command.PerformOn(playerTwoId);

            Assert.That(gameBoard.GetLocationIndexFor(playerTwoId), Is.EqualTo(12));
            Assert.That(banker.GetBalanceFor(playerTwoId), Is.EqualTo(1400));
            Assert.That(banker.GetBalanceFor(playerOneId), Is.EqualTo(1450));
        }
    }
}
