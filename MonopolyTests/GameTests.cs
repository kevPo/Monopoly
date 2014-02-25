using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly;
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
    }
}
