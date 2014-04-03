using System;
using Monopoly.Banker;
using Monopoly.Board;
using Monopoly.JailRoster;
using Monopoly.Locations.Defaults;
using MonopolyTests.Fakes;
using NUnit.Framework;

namespace MonopolyTests.LocationTests.DefaultsTests
{
    [TestFixture]
    public class GoToJailTests
    {
        private Int32 playerId;
        private GoToJail goToJail;
        private TraditionalBanker banker;
        private TraditionalJailRoster jailRoster;
        private GameBoard gameBoard;

        [SetUp]
        public void SetUp()
        {
            playerId = 0;
            var faker = new MotherFaker();
            banker = faker.Banker;
            jailRoster = faker.JailRoster;
            gameBoard = faker.GameBoard;
            goToJail = new GoToJail(30, "Go To Jail", 10, banker, jailRoster, gameBoard);
        }

        [Test]
        public void TestLandedOnSendsPlayerToJail()
        {
            goToJail.LandedOnBy(playerId);
            
            Assert.That(banker.GetBalanceFor(playerId), Is.EqualTo(1500));
            Assert.That(jailRoster.IsInJail(playerId), Is.True);
            Assert.That(gameBoard.GetLocationIndexFor(playerId), Is.EqualTo(10));
        }
    }
}
