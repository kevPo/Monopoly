using System;
using Monopoly.Board;
using MonopolyTests.Fakes;
using NUnit.Framework;

namespace MonopolyTests.LocationTests.ManagersTests
{
    [TestFixture]
    public class GameBoardTests
    {
        private GameBoard gameBoard;

        [SetUp]
        public void SetUp()
        {
            var faker = new MotherFaker();
            gameBoard = new GameBoard();
            gameBoard.SetLocations(faker.LocationFactory.GetLocations(), faker.LocationFactory.GetRailroads(),
                faker.LocationFactory.GetUtilities());
        }

        [Test]
        public void TestPlayerInitializesOnZero()
        {
            Assert.That(gameBoard.GetLocationIndexFor(0), Is.EqualTo(0));
        }

        [Test]
        public void TestLocationIndexSetsPlayersLocationProperly()
        {
            gameBoard.SetLocationIndexFor(0, 10);

            Assert.That(gameBoard.GetLocationIndexFor(0), Is.EqualTo(10));
        }

        [Test]
        public void TestGetNumberOfLocationsReturns40ForTraditionalLocations()
        {
            Assert.That(gameBoard.GetNumberOfLocations(), Is.EqualTo(40));
        }

        [TestCase(0, 5)]
        [TestCase(10, 15)]
        [TestCase(20, 25)]
        [TestCase(25, 35)]
        [TestCase(35, 5)]
        public void TestGetNearestRailRoadForPlayerOn(Int32 startingLocation, Int32 railroadLocation)
        {
            gameBoard.SetLocationIndexFor(0, startingLocation);
            var railroad = gameBoard.GetNearestRailroadFor(0);

            Assert.That(railroad.Index, Is.EqualTo(railroadLocation));
        }

        [TestCase(0, 12)]
        [TestCase(15, 28)]
        [TestCase(28, 12)]
        [TestCase(39, 12)]
        public void TestGetNearestUtilityForPlayerOn(Int32 startingLocation, Int32 utilityLocation)
        {
            gameBoard.SetLocationIndexFor(0, startingLocation);
            var utility = gameBoard.GetNearestUtilityFor(0);

            Assert.That(utility.Index, Is.EqualTo(utilityLocation));
        }
    }
}
