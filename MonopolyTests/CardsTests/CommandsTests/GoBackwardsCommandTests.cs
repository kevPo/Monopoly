using Monopoly.Cards.Commands;
using NUnit.Framework;

namespace MonopolyTests.CardsTests.CommandsTests
{
    [TestFixture]
    public class GoBackwardsCommandTests : CommandTests
    {
        private GoBackwardsCommand command;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            command = new GoBackwardsCommand(3, gameBoard);
        }

        [Test]
        public void TestMoveThreeLocationsBackwardPlacesPlayerThreeLocationsBack()
        {
            gameBoard.SendPlayerDirectlyTo(playerOneId, 13);
            command.PerformOn(playerOneId);

            Assert.That(gameBoard.GetLocationIndexFor(playerOneId), Is.EqualTo(10));
        }

        [Test]
        public void TestMoveThreeLocationsBackwardWhenCurrentlyOnGoSetsPlayerOnThirtySeven()
        {
            command.PerformOn(playerOneId);

            Assert.That(gameBoard.GetLocationIndexFor(playerOneId), Is.EqualTo(37));
        }
    }
}
