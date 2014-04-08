using System;
using Monopoly.GameDriver;
using NUnit.Framework;

namespace MonopolyTests.GameTests
{
    [TestFixture]
    public class TraditionalGameDriverTests
    {
        private IGameDriver gameDriver;

        [SetUp]
        public void SetUp()
        {
            gameDriver = new TraditionalGameDriver();
        }

        [Test]
        public void TestCreateGameWithOnePlayerFails()
        {
            Assert.Throws<InvalidOperationException>(() => gameDriver.PlayGameWith(new[] { "Horse" }));
        }

        [Test]
        public void TestCreateGameWithNinePlayersFails()
        {
            var players = new[] 
            { 
                "Horse",
                "Cat",
                "Wheelbarrow",
                "Battleship",
                "Thimble",
                "Top Hat",
                "Boot",
                "Scottie dog",
                "Racecar"
            };
            Assert.Throws<InvalidOperationException>(() => gameDriver.PlayGameWith(players));
        }

        [Test]
        public void TestPlayGame()
        {
            gameDriver.PlayGameWith(new[] { "Horse", "Car" });
            Assert.That(gameDriver.GetRoundsPlayed(), Is.EqualTo(20));
        }

        [Test]
        public void TestGetRoundsPlayedWhenGameHasNotBeenCreatedReturnsZero()
        {
            Assert.That(gameDriver.GetRoundsPlayed(), Is.EqualTo(0));
        }
    }
}
