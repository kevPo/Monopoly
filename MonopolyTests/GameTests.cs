using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Monopoly;
using MonopolyTests.Fakes;
using NUnit.Framework;

namespace MonopolyTests
{
    [TestFixture]
    public class GameTests
    {
        private FakeBoard fakeBoard;
        private IJailRoster jailRoster;
        private Game game;

        [SetUp]
        public void SetUp()
        {
            jailRoster = new JailRoster();
            fakeBoard = new FakeBoard(new FakeDice(), jailRoster);
            game = new Game(fakeBoard);
        }

        [Test]
        public void TestCreateGameWithTwoPlayersHorseAndCar()
        {
            var players = new [] { new Player("Horse", 0), new Player("Car", 0) };
            game.SetPlayers(players);
            Assert.That(game.Players.Count(), Is.EqualTo(2));
            Assert.That(game.Players.Any(p => p.Name == "Horse"), Is.True);
            Assert.That(game.Players.Any(p => p.Name == "Car"), Is.True);
        }

        [Test]
        public void TestCreateGameWithOnePlayerFails()
        {
            game.SetPlayers(new[] { new Player("Horse", 0) });
            Assert.Throws<InvalidOperationException>(() => game.Play());
        }

        [Test]
        public void TestCreateGameWithNinePlayersFails()
        {
            game.SetPlayers(new[] 
            { 
                new Player("Horse", 0),
                new Player("Cat", 0),
                new Player("Wheelbarrow", 0),
                new Player("Battleship", 0),
                new Player("Thimble", 0),
                new Player("Top Hat", 0),
                new Player("Boot", 0),
                new Player("Scottie dog", 0),
                new Player("Racecar", 0)
            });
            Assert.Throws<InvalidOperationException>(() => game.Play());
        }

        [Test]
        public void TestOrderIsRandom()
        {
            var games = new List<Game>();
            var players = new[] { new Player("Horse", 0), new Player("Car", 0) };
            
            for (var i = 0; i < 50; i++)
            {
                var game = new Game(fakeBoard);
                game.SetPlayers(players);
                games.Add(game);
            }

            var playersStartWithHorse = games.Any(g => g.Players.First().Name == "Horse");
            var playersStartWithCar = games.Any(g => g.Players.First().Name == "Car");

            Assert.That(playersStartWithHorse && playersStartWithCar, Is.True);
        }

        [Test]
        public void TestTwentyRoundsPlayedAndEachPlayerPlayedAllTwenty()
        {
            var fakeBoard = new FakeBoard(new FakeDice(), jailRoster);
            var fakeBoardFactory = new FakeBoardFactory(fakeBoard);
            var horse = new Player("Horse", 0);
            var car = new Player("Car", 0);
            var players = new[] { horse, car };
            
            fakeBoardFactory.Create();
            var game = new Game(fakeBoardFactory.Board);
            game.SetPlayers(players);

            game.Play();
            Assert.That(game.Rounds, Is.EqualTo(20));
            Assert.That(fakeBoard.PlayerTurns[horse], Is.EqualTo(20));
            Assert.That(fakeBoard.PlayerTurns[car], Is.EqualTo(20));
        }

        [Test]
        public void TestThatOrderOfPlayersStayedTheSameDuringGame()
        {
            var fakeBoard = new FakeBoard(new FakeDice(), jailRoster);
            var horse = new Player("Horse", 0);
            var car = new Player("Car", 0);
            var dog = new Player("Dog", 0);
            
            var players = new [] { horse, car, dog };
            var game = new Game(fakeBoard);
            game.SetPlayers(players);

            var playersOrder = String.Format("{0}{1}{2}", game.Players.First().Name, game.Players.ElementAt(1).Name, game.Players.ElementAt(2).Name);
            var turns = String.Empty;

            game.Play();

            var rounds = Regex.Matches(fakeBoard.Turns, playersOrder);
            Assert.That(rounds.Count, Is.EqualTo(20));
        }
    }
}
