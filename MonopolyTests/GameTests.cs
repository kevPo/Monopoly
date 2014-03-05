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
        private Board board;

        [SetUp]
        public void SetUp()
        {
            board = new Board();
        }

        [Test]
        public void TestCreateGameWithTwoPlayersHorseAndCar()
        {
            var players = new [] { new Player("Horse", 0), 
                new Player("Car", 0) };
            var game = new Game(players, board);
            Assert.That(game.Players.Count(), Is.EqualTo(2));
            Assert.That(game.Players.Any(p => p.Name == "Horse"), Is.True);
            Assert.That(game.Players.Any(p => p.Name == "Car"), Is.True);
        }

        [Test]
        public void TestCreateGameWithOnePlayerFails()
        {
            var game = new Game( new [] { new Player("Horse", 0) }, board);
            Assert.Throws<InvalidOperationException>(() => game.Play());
        }

        [Test]
        public void TestCreateGameWithNinePlayersFails()
        {
            var game = new Game(new[] { 
                new Player("Horse", 0),
                new Player("Cat", 0),
                new Player("Wheelbarrow", 0),
                new Player("Battleship", 0),
                new Player("Thimble", 0),
                new Player("Top Hat", 0),
                new Player("Boot", 0),
                new Player("Scottie dog", 0),
                new Player("Racecar", 0)
            }, board);
            Assert.Throws<InvalidOperationException>(() => game.Play());
        }

        [Test]
        public void TestOrderIsRandom()
        {
            var games = new List<Game>();
            var players = new[] { new Player("Horse", 0), new Player("Car", 0) };

            for (var i = 0; i < 50; i++)
                games.Add(new Game(players, board));

            var playersStartWithHorse = games.Any(g => g.Players.First().Name == "Horse");
            var playersStartWithCar = games.Any(g => g.Players.First().Name == "Car");

            Assert.That(playersStartWithHorse && playersStartWithCar, Is.True);
        }

        [Test]
        public void TestTwentyRoundsPlayedAndEachPlayerPlayedAllTwenty()
        {
            var mockBoard = new Mock<IBoard>();
            var horse = new Player("Horse", 0);
            var car = new Player("Car", 0);
            var players = new[] { horse, car };
            var game = new Game(players, mockBoard.Object);

            game.Play();
            mockBoard.Verify(b => b.MovePlayer(car, It.IsAny<Int32>()), Times.Exactly(20));
            mockBoard.Verify(b => b.MovePlayer(horse, It.IsAny<Int32>()), Times.Exactly(20));
            Assert.That(game.Rounds, Is.EqualTo(20));
        }

        [Test]
        public void TestThatOrderOfPlayersStayedTheSameDuringGame()
        {
            var mockBoard = new Mock<IBoard>();
            var horse = new Player("Horse", 0);
            var car = new Player("Car", 0);
            var dog = new Player("Dog", 0);
            
            var players = new [] { horse, car, dog };
            var game = new Game(players, mockBoard.Object);
            var playersOrder = String.Format("{0}{1}{2}", game.Players.First().Name, game.Players.ElementAt(1).Name, game.Players.ElementAt(2).Name);
            var turns = String.Empty;

            mockBoard.Setup(b => b.MovePlayer(horse, It.IsAny<Int32>())).Callback(() => turns += "Horse");
            mockBoard.Setup(b => b.MovePlayer(car, It.IsAny<Int32>())).Callback(() => turns += "Car");
            mockBoard.Setup(b => b.MovePlayer(dog, It.IsAny<Int32>())).Callback(() => turns += "Dog");

            game.Play();

            var rounds = Regex.Matches(turns, playersOrder);
            Assert.That(rounds.Count, Is.EqualTo(20));
        }
    }
}
