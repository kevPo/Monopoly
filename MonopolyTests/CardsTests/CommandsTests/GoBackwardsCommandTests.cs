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
            gameBoard.SetLocationIndexFor(playerOneId, 13);
            command.PerformOn(playerOneId);

            Assert.That(gameBoard.GetLocationIndexFor(playerOneId), Is.EqualTo(10));
        }

        [Test]
        public void TestMoveThreeLocationsBackwardOverGoPlacesPlayerOnProperLocation()
        {
            gameBoard.SetLocationIndexFor(playerOneId, 2);
            command.PerformOn(playerOneId);

            Assert.That(gameBoard.GetLocationIndexFor(playerOneId), Is.EqualTo(39));
        }

        [Test]
        public void TestMoveThreeLocationsBackwardWhenCurrentlyOnGoSetsPlayerOnThirtySeven()
        {
            gameBoard.SetLocationIndexFor(playerOneId, 0);
            command.PerformOn(playerOneId);

            Assert.That(gameBoard.GetLocationIndexFor(playerOneId), Is.EqualTo(37));
        }
    }
}
