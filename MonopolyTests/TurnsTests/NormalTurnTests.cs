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
    public class NormalTurnTests
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
            var playerRepository = new PlayerRepository(new IPlayer[] { player });
            var boardFactory = new FakeTraditionalBoardFactory(new TraditionalDice(), playerRepository, jailRoster);
            locations = boardFactory.GetTraditionalLocations();
            player.LocationIndex = 0;
            playerService = new PlayerService(playerRepository);
        }

        [Test]
        public void TestPlayerOn0Rolls7AndMovesTo7()
        {
            PlayerTakesTurnRollingA(7);

            Assert.That(player.LocationIndex, Is.EqualTo(7));
        }

        private void PlayerTakesTurnRollingA(Int32 roll)
        {
            var dice = new FakeDice(new [] { new FakeRoll(roll, 0) });
            var turn = new NormalTurn(player.Id, dice, jailRoster, playerService, locations);
            turn.Take();
        }

        [Test]
        public void TestPlayerOn39Rolls6AndEndsUpOn5()
        {
            PlayerTakesTurnRollingA(39);
            PlayerTakesTurnRollingA(6);

            Assert.That(player.LocationIndex, Is.EqualTo(5));
        }

        [Test]
        public void TestPlayerPassesGoTwiceWithOneTurnAndBalanceIncreases400()
        {
            PlayerTakesTurnRollingA(80);

            Assert.That(player.Balance, Is.EqualTo(2400));
        }

        [Test]
        public void TestBalanceDoesNotIncreaseForNonGoLocations()
        {
            var previousBalance = player.Balance;
            PlayerTakesTurnRollingA(5);

            Assert.That(player.Balance <= previousBalance, Is.True);
        }

        [Test]
        public void TestPassGoToJailButNotStartDoesNotChangeBalance()
        {
            PlayerTakesTurnRollingA(33);

            Assert.That(player.LocationIndex, Is.EqualTo(33));
            Assert.That(player.Balance, Is.EqualTo(2000));
        }

        [Test]
        public void TestDouble6AndNonDouble4LandsPlayerOn10InOneTurn()
        {
            var rolls = new []
                    {
                        new FakeRoll(3, 3),
                        new FakeRoll(3, 1)
                    };
            var turn = CreateTurnWith(new FakeDice(rolls));
            turn.Take();

            // Player lands on Oriental Ave and buys it for $100 on first roll
            Assert.That(player.Balance, Is.EqualTo(1900));
            Assert.That(player.LocationIndex, Is.EqualTo(10));
        }

        private Turn CreateTurnWith(IDice dice)
        {
            return new NormalTurn(player.Id, dice, jailRoster, playerService, locations);
        }

        [Test]
        public void TestDoublesThrownTwiceAndPlayerLandsOnThreeLocations()
        {
            var rolls = new []
                    {
                        new FakeRoll(3, 3),
                        new FakeRoll(5, 5),
                        new FakeRoll(3, 1)
                    };
            var turn = CreateTurnWith(new FakeDice(rolls));
            turn.Take();

            // Player should land on and buy Oriental (6) for $100
            // and St. James (16) for $180.
            Assert.That(player.Balance, Is.EqualTo(1720));
            Assert.That(player.LocationIndex, Is.EqualTo(20));
        }

        [Test]
        public void TestDoublesThrownThreeTimesAndPlayerLandsOnJustVisiting()
        {
            var rolls = new []
                    {
                        new FakeRoll(3, 3),
                        new FakeRoll(5, 5),
                        new FakeRoll(6, 6),
                        new FakeRoll(3, 1)
                    };
            var turn = CreateTurnWith(new FakeDice(rolls));
            turn.Take();

            // Player should land on and buy Oriental (6) for $100
            // and St. James (16) for $180.
            Assert.That(player.Balance, Is.EqualTo(1720));
            Assert.That(player.LocationIndex, Is.EqualTo(10));
        }

        [Test]
        public void RollDoubles3TimesWithoutPassingGoPutsPlayerInJailWithoutCollectingSalary()
        {
            var rolls = new []
                    {
                        new FakeRoll(5, 5),
                        new FakeRoll(5, 5),
                        new FakeRoll(3, 3),
                        new FakeRoll(3, 1)
                    };
            var turn = CreateTurnWith(new FakeDice(rolls));
            turn.Take();

            Assert.That(player.Balance, Is.EqualTo(2000));
            Assert.That(player.LocationIndex, Is.EqualTo(10));
        }

        [Test]
        public void RollDoubles3TimesPassingGoAndCollectingSalaryPutsPlayerInJailWithSalary()
        {
            var rolls = new []
                    {
                        new FakeRoll(19, 19),
                        new FakeRoll(6, 6),
                        new FakeRoll(5, 5),
                        new FakeRoll(3, 1)
                    };
            var turn = CreateTurnWith(new FakeDice(rolls));
            turn.Take();

            Assert.That(player.Balance, Is.EqualTo(2125));
            Assert.That(player.LocationIndex, Is.EqualTo(10));
        }

        [Test]
        public void TestPlayerThrowsNonDoublesLandsOnGoToJailWithBalanceNotChangingAndTurnIsOver()
        {
            var fakeDice = new FakeDice(new [] { new FakeRoll(30, 0) });
            var turn = CreateTurnWith(fakeDice);
            turn.Take();

            Assert.That(player.Balance, Is.EqualTo(2000));
            Assert.That(player.LocationIndex, Is.EqualTo(10));
        }

        [Test]
        public void TestPlayerRollsDoublesLandsOnGoToJailTurnIsOverAndBalanceNotChanged()
        {
            var rolls = new []
                    {
                        new FakeRoll(15, 15),
                        new FakeRoll(3, 1)
                    };
            var turn = CreateTurnWith(new FakeDice(rolls));
            turn.Take();

            Assert.That(player.Balance, Is.EqualTo(2000));
            Assert.That(player.LocationIndex, Is.EqualTo(10));
        }
    }
}
