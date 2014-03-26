﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Monopoly;
using Monopoly.TraditionalMonopoly;
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
            jailRoster = new TraditionalJailRoster();
        }

        [Test]
        public void TestPlayerOrderIsRandom()
        {
            var boards = new List<FakeBoard>();
            var players = new[] { new Player(0, "Horse", 0), new Player(1, "Car", 0) };
            var playerRepository = new PlayerRepository(players);
            for (var i = 0; i < 50; i++)
                boards.Add(new FakeBoard(new FakeDice(), playerRepository, jailRoster));

            var playersStartWithHorse = boards.Any(g => g.GetPlayers().First().Name == "Horse");
            var playersStartWithCar = boards.Any(g => g.GetPlayers().First().Name == "Car");

            Assert.That(playersStartWithHorse && playersStartWithCar, Is.True);
        }

        [Test]
        public void TestTwentyRoundsPlayedAndEachPlayerPlayedAllTwenty()
        {
            var horse = new Player(0, "Horse", 0);
            var car = new Player(1, "Car", 0);
            var players = new[] { horse, car };
            var playerRepository = new PlayerRepository(players);
            var fakeBoard = new FakeBoard(new FakeDice(), playerRepository, jailRoster);

            var game = new Game(fakeBoard);
            game.Play();

            Assert.That(game.Rounds, Is.EqualTo(20));
            Assert.That(fakeBoard.PlayerTurns[horse], Is.EqualTo(20));
            Assert.That(fakeBoard.PlayerTurns[car], Is.EqualTo(20));
        }

        [Test]
        public void TestThatOrderOfPlayersStayedTheSameDuringGame()
        {
            var horse = new Player(0, "Horse", 0);
            var car = new Player(1, "Car", 0);
            var dog = new Player(2, "Dog", 0);
            var players = new[] { horse, car, dog };
            var playerRepository = new PlayerRepository(players);
            var fakeBoard = new FakeBoard(new FakeDice(), playerRepository, new FakeJailRoster());
            var game = new Game(fakeBoard);
            var gamePlayers = fakeBoard.GetPlayers();

            var playersOrder = String.Format("{0}{1}{2}",
                gamePlayers.First().Name, gamePlayers.ElementAt(1).Name, gamePlayers.ElementAt(2).Name);
            var turns = String.Empty;
            game.Play();
            var rounds = Regex.Matches(fakeBoard.Turns, playersOrder);

            Assert.That(rounds.Count, Is.EqualTo(20));
        }
    }
}
