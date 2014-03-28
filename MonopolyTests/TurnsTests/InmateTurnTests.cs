using System;
using System.Collections.Generic;
using Monopoly;
using Monopoly.Locations;
using Monopoly.TraditionalMonopoly;
using Monopoly.Turns;
using MonopolyTests.Fakes;
using NUnit.Framework;

namespace MonopolyTests.TurnsTests
{
    [TestFixture]
    public class InmateTurnTests
    {
        private TraditionalJailRoster jailRoster;
        private IPlayer player;
        private IEnumerable<Location> locations;
        private IPlayerService playerService;

        [SetUp]
        public void SetUp()
        {
            jailRoster = new TraditionalJailRoster();
            player = new Player(0, "horse", 2000);
            var playerRepository = new PlayerRepository(new [] { player });
            var boardFactory = new FakeTraditionalBoardFactory(new TraditionalDice(), playerRepository, jailRoster);
            locations = boardFactory.GetTraditionalLocations();
            playerService = new PlayerService(playerRepository);
            player.LocationIndex = 10;
            jailRoster.Add(player.Id);
        }

        [Test]
        public void TestInmateRollsDoublesAndGetsOutOfJailButDoesNotMoveAgain()
        {
            var rolls = new Tuple<Int32, String>[]
                    {
                        Tuple.Create<Int32, String>(10, "D"),
                        Tuple.Create<Int32, String>(5, "")
                    };
            var turn = CreateTurnWith(new FakeDiceDoublesRoller(rolls));

            turn.Take();
            Assert.That(player.LocationIndex, Is.EqualTo(20));
            Assert.That(player.Balance, Is.EqualTo(2000));
        }

        private Turn CreateTurnWith(IDice dice)
        {
            return new InmateTurn(player.Id, dice, jailRoster, playerService, locations);
        }

        [Test]
        public void TestInmateSecondTurnInJailRollsDoublesAndGetsOutOfJail()
        {
            var rolls = new Tuple<Int32, String>[]
                    {
                        Tuple.Create<Int32, String>(5, ""),
                        Tuple.Create<Int32, String>(10, "D"),
                        Tuple.Create<Int32, String>(5, "")
                    };
            var turn = CreateTurnWith(new FakeDiceDoublesRoller(rolls));
            turn.Take();
            turn.Take();

            Assert.That(player.LocationIndex, Is.EqualTo(20));
            Assert.That(player.Balance, Is.EqualTo(2000));
        }

        [Test]
        public void TestInmateThirdTurnInJailRollsDoubleAndGetsOutOfJail()
        {
            var rolls = new Tuple<Int32, String>[]
                    {
                        Tuple.Create<Int32, String>(5, ""),
                        Tuple.Create<Int32, String>(10, ""),
                        Tuple.Create<Int32, String>(10, "D"),
                        Tuple.Create<Int32, String>(10, ""),
                    };
            var turn = CreateTurnWith(new FakeDiceDoublesRoller(rolls));
            turn.Take();
            turn.Take();
            turn.Take();

            Assert.That(player.LocationIndex, Is.EqualTo(20));
            Assert.That(player.Balance, Is.EqualTo(2000));
        }

        [Test]
        public void TestInmateDoesNotRollDoublesOnFirstTurnInJailAndStaysInJail()
        {
            PlayerTakesTurnRollingA(10);

            Assert.That(player.LocationIndex, Is.EqualTo(10));
        }

        private void PlayerTakesTurnRollingA(Int32 roll)
        {
            var fakeDice = new FakeDice();
            fakeDice.NextRoll = roll;
            var turn = CreateTurnWith(fakeDice);
            turn.Take();
        }

        [Test]
        public void TestInmateDoesNotRollDoublesOnFirstOrSecondTurnAndStaysInJail()
        {
            PlayerTakesTurnRollingA(10);
            PlayerTakesTurnRollingA(10);

            Assert.That(player.LocationIndex, Is.EqualTo(10));
        }

        [Test]
        public void TestInmateTakesThreeTurnsWithoutDoublesAndPays50ToGetOutOfJail()
        {
            PlayerTakesTurnRollingA(10);
            PlayerTakesTurnRollingA(10);
            PlayerTakesTurnRollingA(10);

            Assert.That(player.LocationIndex, Is.EqualTo(20));
            Assert.That(player.Balance, Is.EqualTo(1950));
        }

        //[Test]
        //public void TestInmatePays50RollsDoublesAndRollsAgainGetsPlayerOutOfJail()
        //{
        //    var rolls = new Tuple<Int32, String>[]
        //    {
        //        Tuple.Create<Int32, String>(10, "D"),
        //        Tuple.Create<Int32, String>(4, "")
        //    };
        //    var doubleDice = new FakeDiceDoublesRoller(rolls);
        //    var turn = CreateTurnWith(new FakeDiceDoublesRoller(rolls));
        //    turn.Take();

        //    Assert.That(player.Balance, Is.EqualTo(1750));
        //    Assert.That(player.Location.Index, Is.EqualTo(25));
        //}

        //[Test]
        //public void TestInmatePays50RollsNonDoublesGetsOutOfJail()
        //{
        //    PlayerTakesTurnRollingA(10);

        //    Assert.That(player.Balance, Is.EqualTo(1950));
        //    Assert.That(player.Location.Index, Is.EqualTo(20));
        //}

    }
}
