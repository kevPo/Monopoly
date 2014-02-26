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
        [Test]
        public void TestCreateGameWithTwoPlayersHorseAndCar()
        {
            var game = new Game(new [] { new Player("Horse"), new Player("Car") });
            Assert.That(game.Players.Count, Is.EqualTo(2));
            Assert.That(game.Players.Any(p => p.Name == "Horse"), Is.True);
            Assert.That(game.Players.Any(p => p.Name == "Car"), Is.True);
        }

        [Test]
        public void TestCreateGameWithOnePlayerFails()
        {
            var game = new Game( new [] { new Player("Horse") });
            Assert.Throws<InvalidOperationException>(() => game.Play());
        }

        [Test]
        public void TestCreateGameWithNinePlayersFails()
        {
            var game = new Game(new[] { 
                new Player("Horse"),
                new Player("Cat"),
                new Player("Wheelbarrow"),
                new Player("Battleship"),
                new Player("Thimble"),
                new Player("Top Hat"),
                new Player("Boot"),
                new Player("Scottie dog"),
                new Player("Racecar")
            });
            Assert.Throws<InvalidOperationException>(() => game.Play());
        }

        [Test]
        public void TestOrderIsRandom()
        {
            var games = new List<Game>();

            for (var i = 0; i < 50; i++)
                games.Add(new Game(new[] { new Player("Horse"), new Player("Car") }));

            var playersStartWithHorse = games.Any(g => g.Players[0].Name == "Horse");
            var playersStartWithCar = games.Any(g => g.Players[0].Name == "Car");

            Assert.That(playersStartWithHorse && playersStartWithCar, Is.True);
        }

        [Test]
        public void TestTwentyRoundsPlayedAndEachPlayerPlayedAllTwenty()
        {
            var mockHorse = new Mock<IPlayer>();
            var mockCar = new Mock<IPlayer>();
            var game = new Game(new List<IPlayer> { mockHorse.Object, mockCar.Object });

            game.Play();
            mockHorse.Verify(h => h.TakeTurn(), Times.Exactly(20));
            mockCar.Verify(c => c.TakeTurn(), Times.Exactly(20));
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

            var game = new Game(new List<IPlayer> { mockHorse.Object, mockCar.Object, mockDog.Object });
            var playersOrder = String.Format("{0}{1}{2}", game.Players[0].Name, game.Players[1].Name, game.Players[2].Name);
            
            var turns = String.Empty;

            mockHorse.Setup(h => h.TakeTurn()).Callback(() => turns += "Horse");
            mockCar.Setup(c => c.TakeTurn()).Callback(() => turns += "Car");
            mockDog.Setup(d => d.TakeTurn()).Callback(() => turns += "Dog");

            game.Play();

            var rounds = Regex.Matches(turns, playersOrder);
            Assert.That(rounds.Count, Is.EqualTo(20));
        }
    }
}
