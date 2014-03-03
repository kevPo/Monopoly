using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Monopoly;
using Moq;
using NUnit.Framework;

namespace MonopolyTests
{
    [TestFixture]
    public class GameTests
    {
        private GameMediator gameMediator;

        [SetUp]
        public void SetUp()
        {
            gameMediator = new GameMediator(new Board(), new LocationAssessor());
        }

        [Test]
        public void TestCreateGameWithTwoPlayersHorseAndCar()
        {
            var players = new [] { new Player("Horse", 0, gameMediator), 
                new Player("Car", 0, gameMediator) };
            var game = new Game(players);
            Assert.That(game.Players.Count(), Is.EqualTo(2));
            Assert.That(game.Players.Any(p => p.Name == "Horse"), Is.True);
            Assert.That(game.Players.Any(p => p.Name == "Car"), Is.True);
        }

        [Test]
        public void TestCreateGameWithOnePlayerFails()
        {
            var game = new Game( new [] { new Player("Horse", 0, gameMediator) });
            Assert.Throws<InvalidOperationException>(() => game.Play());
        }

        [Test]
        public void TestCreateGameWithNinePlayersFails()
        {
            var game = new Game(new[] { 
                new Player("Horse", 0, gameMediator),
                new Player("Cat", 0, gameMediator),
                new Player("Wheelbarrow", 0, gameMediator),
                new Player("Battleship", 0, gameMediator),
                new Player("Thimble", 0, gameMediator),
                new Player("Top Hat", 0, gameMediator),
                new Player("Boot", 0, gameMediator),
                new Player("Scottie dog", 0, gameMediator),
                new Player("Racecar", 0, gameMediator)
            });
            Assert.Throws<InvalidOperationException>(() => game.Play());
        }

        [Test]
        public void TestOrderIsRandom()
        {
            var games = new List<Game>();
            var players = new[] { new Player("Horse", 0, gameMediator),
                new Player("Car", 0, gameMediator) };

            for (var i = 0; i < 50; i++)
                games.Add(new Game(players));

            var playersStartWithHorse = games.Any(g => g.Players.First().Name == "Horse");
            var playersStartWithCar = games.Any(g => g.Players.First().Name == "Car");

            Assert.That(playersStartWithHorse && playersStartWithCar, Is.True);
        }

        [Test]
        public void TestTwentyRoundsPlayedAndEachPlayerPlayedAllTwenty()
        {
            var mockHorse = new Mock<IPlayer>();
            var mockCar = new Mock<IPlayer>();
            var players = new[] { mockHorse.Object, mockCar.Object };
            var game = new Game(players);

            game.Play();
            mockHorse.Verify(h => h.TakeTurn(It.IsAny<Int32>()), Times.Exactly(20));
            mockCar.Verify(c => c.TakeTurn(It.IsAny<Int32>()), Times.Exactly(20));
            Assert.That(game.Rounds, Is.EqualTo(20));
        }

        [Test]
        public void TestThatOrderOfPlayersStayedTheSameDuringGame()
        {
            var mockHorse = new Mock<IPlayer>();
            var mockCar = new Mock<IPlayer>();
            var mockDog = new Mock<IPlayer>();

            mockHorse.Setup(h => h.Name).Returns("Horse");
            mockCar.Setup(c => c.Name).Returns("Car");
            mockDog.Setup(d => d.Name).Returns("Dog");

            var players = new [] { mockHorse.Object, mockCar.Object, mockDog.Object };
            var game = new Game(players);
            var playersOrder = String.Format("{0}{1}{2}", game.Players.First().Name, game.Players.ElementAt(1).Name, game.Players.ElementAt(2).Name);
            var turns = String.Empty;

            mockHorse.Setup(h => h.TakeTurn(It.IsAny<Int32>())).Callback(() => turns += "Horse");
            mockCar.Setup(c => c.TakeTurn(It.IsAny<Int32>())).Callback(() => turns += "Car");
            mockDog.Setup(d => d.TakeTurn(It.IsAny<Int32>())).Callback(() => turns += "Dog");

            game.Play();

            var rounds = Regex.Matches(turns, playersOrder);
            Assert.That(rounds.Count, Is.EqualTo(20));
        }
    }
}
