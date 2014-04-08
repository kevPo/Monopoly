using Monopoly.Cards.Commands;
using NUnit.Framework;

namespace MonopolyTests.CardsTests.CommandsTests
{
    [TestFixture]
    public class AdvanceAndCollectSalaryIfGoIsPassedCommandTests : CommandTests
    {
        private AdvanceAndCollectSalaryIfGoIsPassedCommand command;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            command = new AdvanceAndCollectSalaryIfGoIsPassedCommand(11, gameBoard);
        }

        [Test]
        public void TestAdvancingPassedGoMovesPlayerToDestinationAndPlayerCollects200()
        {
            gameBoard.SendPlayerDirectlyTo(0, 20);
            command.PerformOn(0);

            Assert.That(gameBoard.GetLocationIndexFor(0), Is.EqualTo(11));
            // player buys location for 140 
            Assert.That(banker.GetBalanceFor(0), Is.EqualTo(1560));
        }

        [Test]
        public void TestNotAdvancingPassedGoAndPlayerDoesNotCollect200()
        {
            gameBoard.SendPlayerDirectlyTo(0, 10);
            command.PerformOn(0);

            Assert.That(gameBoard.GetLocationIndexFor(0), Is.EqualTo(11));
            // player buys location for 140 
            Assert.That(banker.GetBalanceFor(0), Is.EqualTo(1360));
        }
    }
}
