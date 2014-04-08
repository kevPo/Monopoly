using System;
using System.Linq;
using Monopoly.Banker;
using Monopoly.Board;
using Monopoly.Locations.Defaults;
using Monopoly.Locations.Propertys;
using MonopolyTests.Fakes;
using NUnit.Framework;

namespace MonopolyTests.LocationTests.ManagersTests
{
    [TestFixture]
    public class GameBoardTests
    {
        private IBoard board;
        private IBanker banker;
        private Int32 playerId;

        [SetUp]
        public void SetUp()
        {
            playerId = 0;
            var faker = new MotherFaker();
            banker = faker.Banker;
            board = new GameBoard(banker);
            board.SetLocations(faker.LocationFactory.GetLocations(), faker.LocationFactory.GetRailroads(),
                faker.LocationFactory.GetUtilities());
        }

        [Test]
        public void TestPlayerInitializesOnZero()
        {
            Assert.That(board.GetLocationIndexFor(playerId), Is.EqualTo(0));
        }

        [TestCase(0, 12)]
        [TestCase(15, 28)]
        [TestCase(28, 12)]
        [TestCase(39, 12)]
        public void TestSendPlayerToNearestUtility(Int32 startingLocation, Int32 utilityLocation)
        {
            board.MovePlayerTo(playerId, startingLocation);
            board.SendPlayerToNearestUtility(playerId);

            Assert.That(board.GetLocationIndexFor(playerId), Is.EqualTo(utilityLocation));
        }

        [TestCase(0, 5)]
        [TestCase(10, 15)]
        [TestCase(20, 25)]
        [TestCase(25, 35)]
        [TestCase(35, 5)]
        public void TestSendPlayerToNearestRailroad(Int32 startingLocation, Int32 railroadLocation)
        {
            board.MovePlayerTo(playerId, startingLocation);
            board.SendPlayerToNearestRailroad(playerId);

            Assert.That(board.GetLocationIndexFor(playerId), Is.EqualTo(railroadLocation));
        }

        [Test]
        public void TestPlayerPassesOverIncomeTaxAndUnownedPropertiesChangesNothing()
        {
            board.MovePlayerTo(playerId, 10);
            Assert.That(banker.GetBalanceFor(playerId), Is.EqualTo(1500));
        }

        [Test]
        public void TestPlayerPassesGoTwiceWithOneTurnAndBalanceIncreasesByFourHundred()
        {
            board.MovePlayer(playerId, 80);
            Assert.That(banker.GetBalanceFor(playerId), Is.EqualTo(1900));
        }

        [Test]
        public void TestPlayerPassesGoOnceAndReceivesTwoHundredDollarBonus()
        {
            board.MovePlayer(playerId, 50);
            Assert.That(banker.GetBalanceFor(playerId), Is.EqualTo(1700));
        }

        [Test]
        public void TestPlayerDoesNotPassAroundTheBoardAndBalanceDoesNotChange()
        {
            board.MovePlayer(playerId, 20);
            Assert.That(banker.GetBalanceFor(playerId), Is.EqualTo(1500));
        }

        [Test]
        public void TestBalanceDoesNotIncreaseForNonGoLocations()
        {
            var previousBalance = banker.GetBalanceFor(playerId);
            board.MovePlayer(playerId, 5);
            Assert.That(banker.GetBalanceFor(playerId) <= previousBalance, Is.True);
        }

        [Test]
        public void TestSetLocationsBuildsLocationsList()
        {
            var board = new GameBoard(banker);
            var location = new NullLocation(0, "null");
            var railroad = new Railroad(1, "railroad", 10, 10, banker, new Railroad[] {});
            var utility = new Utility(2, "utility", 10, 10, banker, new Utility[] {}, new FakeDice());
            board.SetLocations(new Location[] { location }, new Railroad[] { railroad }, new Utility[] { utility });

            Assert.That(board.Locations.Count(), Is.EqualTo(3));
        }

        [Test]
        public void TestMovePlayerToLocationAtTenMovesPlayerToLocationTen()
        {
            board.MovePlayerTo(playerId, 10);
            Assert.That(board.GetLocationIndexFor(playerId), Is.EqualTo(10));
        }

        [Test]
        public void TestMovePlayerToTenFromTwentyGivesPlayerTwoHundredDollarBonus()
        {
            board.MovePlayer(playerId, 20);
            board.MovePlayerTo(playerId, 10);

            Assert.That(banker.GetBalanceFor(playerId), Is.EqualTo(1700));
        }

        [Test]
        public void TestSendPlayerDirectlyToLocationTwentyFromZero()
        {
            board.SendPlayerDirectlyTo(playerId, 20);
            Assert.That(board.GetLocationIndexFor(playerId), Is.EqualTo(20));
        }

        [Test]
        public void TestSendPlayerPassedGoDirectlyDoesNotGivePlayerTwoHundredDollarBonus()
        {
            board.MovePlayerTo(playerId, 20);
            board.SendPlayerDirectlyTo(playerId, 10);

            Assert.That(board.GetLocationIndexFor(playerId), Is.EqualTo(10));
            Assert.That(banker.GetBalanceFor(playerId), Is.EqualTo(1500));
        }

        [Test]
        public void TestSendPlayerDirectlyToJail()
        {
            board.SendPlayerDirectlyToJail(playerId);
            Assert.That(board.GetLocationIndexFor(playerId), Is.EqualTo(10));
        }
    }
}
