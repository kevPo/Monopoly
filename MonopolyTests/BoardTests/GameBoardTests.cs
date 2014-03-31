using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Monopoly.Game;
using Monopoly.JailRoster;
using Monopoly.Players;
using MonopolyTests.Fakes;
using NUnit.Framework;

namespace MonopolyTests.BoardTests
{
    [TestFixture]
    public class GameBoardTests
    {
        private IJailRoster jailRoster;

        [SetUp]
        public void SetUp()
        {
            jailRoster = new FakeJailRoster();
        }

        [Test]
        public void TestPlayerOrderIsRandom()
        {
            var boards = new List<FakeBoard>();
            var players = new[] { new Player(0, "Horse"), new Player(1, "Car") };
            var playerRepository = new PlayerRepository(players);
            for (var i = 0; i < 50; i++)
                boards.Add(new FakeBoard(new FakeDice(), playerRepository, jailRoster));

            var playersStartWithHorse = boards.Any(g => g.GetPlayers().First() == 0);
            var playersStartWithCar = boards.Any(g => g.GetPlayers().First() == 1);

            Assert.That(playersStartWithHorse && playersStartWithCar, Is.True);
        }

        [Test]
        public void TestTwentyRoundsPlayedAndEachPlayerPlayedAllTwenty()
        {
            var horse = new Player(0, "Horse");
            var car = new Player(1, "Car");
            var players = new[] { horse, car };
            var playerRepository = new PlayerRepository(players);
            var fakeBoard = new FakeBoard(new FakeDice(), playerRepository, jailRoster);

            var game = new Game(fakeBoard);
            game.Play();

            Assert.That(game.Rounds, Is.EqualTo(20));
            Assert.That(fakeBoard.PlayerTurns[horse.Id], Is.EqualTo(20));
            Assert.That(fakeBoard.PlayerTurns[car.Id], Is.EqualTo(20));
        }

        [Test]
        public void TestThatOrderOfPlayersStayedTheSameDuringGame()
        {
            var horse = new Player(0, "Horse");
            var car = new Player(1, "Car");
            var dog = new Player(2, "Dog");
            var players = new[] { horse, car, dog };
            var playerRepository = new PlayerRepository(players);
            var fakeBoard = new FakeBoard(new FakeDice(), playerRepository, new FakeJailRoster());
            var game = new Game(fakeBoard);
            var gamePlayers = fakeBoard.GetPlayers();

            var playersOrder = String.Format("{0}{1}{2}",
                gamePlayers.First(), gamePlayers.ElementAt(1), gamePlayers.ElementAt(2));
            var turns = String.Empty;
            game.Play();
            var rounds = Regex.Matches(fakeBoard.Turns, playersOrder);

            Assert.That(rounds.Count, Is.EqualTo(20));
        }
    }
}
