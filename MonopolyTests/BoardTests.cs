﻿using Monopoly;
using NUnit.Framework;

namespace MonopolyTests
{
    [TestFixture]
    public class BoardTests
    {
        private Board board;

        [SetUp]
        public void SetUp()
        {
            board = new Board();
        }

        [Test]
        public void TestGetStartingPositionReturnsGo()
        {
            var start = board.GetStartingLocation();
            Assert.That(start, Is.EqualTo("Go"));
        }

        [Test]
        public void TestBalanceIncreasesBy200WhenLandingOnGo()
        {
            var result = board.UpdateLocation("Go", 40);            
            Assert.That(result.Balance, Is.EqualTo(200));
        }

        [Test]
        public void TestBalanceDoesNotIncreaseForNormalLocations()
        {
            var result = board.UpdateLocation("Go", 5);
            Assert.That(result.Balance , Is.EqualTo(0));
        }

        [Test]
        public void TestBalanceIncreasesAfterPassingGo()
        {
            var result = board.UpdateLocation("Park Place", 5);
            Assert.That(result.Balance, Is.EqualTo(200));
        }

        [Test]
        public void TestOnGoUpdateLocationWithoutMovingAndBalanceDoesNotChange()
        {
            var result = board.UpdateLocation("Go", 0);
            Assert.That(result.Balance, Is.EqualTo(0));
        }
    }
}
