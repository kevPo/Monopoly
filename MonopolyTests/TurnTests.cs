using System;
using System.Collections.Generic;
using Monopoly;
using Monopoly.Locations;
using Monopoly.TraditionalMonopoly;
using MonopolyTests.Fakes;
using NUnit.Framework;

namespace MonopolyTests
{
    [TestFixture]
    public class TurnTests
    {
        private TraditionalJailRoster jailRoster;
        private IEnumerable<Location> locations;
        private IPlayer player;
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
        public void TestOnGoUpdateLocationWithoutMovingAndBalanceDoesNotChange()
        {
            PlayerTakesTurnRollingA(0);

            Assert.That(player.Balance, Is.EqualTo(2000));
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
            var rolls = new Tuple<Int32, String>[]
            {
                Tuple.Create<Int32, String>(6, "D"),
                Tuple.Create<Int32, String>(4, "")
            };
            var turn = CreateTurnWith(new FakeDiceDoublesRoller(rolls));
            turn.TakeFor(player.Id);

            // Player lands on Oriental Ave and buys it for $100 on first roll
            Assert.That(player.Balance, Is.EqualTo(1900));
            Assert.That(player.LocationIndex, Is.EqualTo(10));
        }

        private Turn CreateTurnWith(IDice dice)
        {
            return new Turn(locations, jailRoster, playerService, dice);
        }

        [Test]
        public void TestDoublesThrownTwiceAndPlayerLandsOnThreeLocations()
        {
            var rolls = new Tuple<Int32, String>[]
            {
                Tuple.Create<Int32, String>(6, "D"),
                Tuple.Create<Int32, String>(10, "D"),
                Tuple.Create<Int32, String>(4, "")
            };
            var turn = CreateTurnWith(new FakeDiceDoublesRoller(rolls));
            turn.TakeFor(player.Id);

            // Player should land on and buy Oriental (6) for $100
            // and St. James (16) for $180.
            Assert.That(player.Balance, Is.EqualTo(1720));
            Assert.That(player.LocationIndex, Is.EqualTo(20));
        }

        [Test]
        public void TestDoublesThrownThreeTimesAndPlayerLandsOnJustVisiting()
        {
            var rolls = new Tuple<Int32, String>[]
            {
                Tuple.Create<Int32, String>(6, "D"),
                Tuple.Create<Int32, String>(10, "D"),
                Tuple.Create<Int32, String>(12, "D"),
                Tuple.Create<Int32, String>(4, "")
            };
            var turn = CreateTurnWith(new FakeDiceDoublesRoller(rolls));
            turn.TakeFor(player.Id);

            // Player should land on and buy Oriental (6) for $100
            // and St. James (16) for $180.
            Assert.That(player.Balance, Is.EqualTo(1720));
            Assert.That(player.LocationIndex, Is.EqualTo(10));
        }

        [Test]
        public void RollDoubles3TimesWithoutPassingGoPutsPlayerInJailWithoutCollectingSalary()
        {
            var rolls = new Tuple<Int32, String>[]
            {
                Tuple.Create<Int32, String>(10, "D"),
                Tuple.Create<Int32, String>(10, "D"),
                Tuple.Create<Int32, String>(6, "D"),
                Tuple.Create<Int32, String>(4, "")
            };
            var turn = CreateTurnWith(new FakeDiceDoublesRoller(rolls));
            turn.TakeFor(player.Id);

            Assert.That(player.Balance, Is.EqualTo(2000));
            Assert.That(player.LocationIndex, Is.EqualTo(10));
        }

        [Test]
        public void RollDoubles3TimesPassingGoAndCollectingSalaryPutsPlayerInJailWithSalary()
        {
            var rolls = new Tuple<Int32, String>[]
            {
                Tuple.Create<Int32, String>(38, "D"),
                Tuple.Create<Int32, String>(12, "D"),
                Tuple.Create<Int32, String>(10, "D"),
                Tuple.Create<Int32, String>(4, "")
            };
            var turn = CreateTurnWith(new FakeDiceDoublesRoller(rolls));
            turn.TakeFor(player.Id);

            Assert.That(player.Balance, Is.EqualTo(2125));
            Assert.That(player.LocationIndex, Is.EqualTo(10));
        } 

        [Test]
        public void TestPlayerThrowsNonDoublesLandsOnGoToJailWithBalanceNotChangingAndTurnIsOver()
        {
            var fakeDice = new FakeDice();
            fakeDice.NextRoll = 30;
            var turn = CreateTurnWith(fakeDice);
            turn.TakeFor(player.Id);

            Assert.That(player.Balance, Is.EqualTo(2000));
            Assert.That(player.LocationIndex, Is.EqualTo(10));
        }

        [Test]
        public void TestPlayerRollsDoublesLandsOnGoToJailTurnIsOverAndBalanceNotChanged()
        {
            var rolls = new Tuple<Int32, String>[]
            {
                Tuple.Create<Int32, String>(30, "D"),
                Tuple.Create<Int32, String>(4, "")
            };
            var turn = CreateTurnWith(new FakeDiceDoublesRoller(rolls));
            turn.TakeFor(player.Id);

            Assert.That(player.Balance, Is.EqualTo(2000));
            Assert.That(player.LocationIndex, Is.EqualTo(10));
        }

        [Test]
        public void TestPlayerInJailRollsDoublesAndGetsOutOfJailButDoesNotMoveAgain()
        {
            var rolls = new Tuple<Int32, String>[]
            {
                Tuple.Create<Int32, String>(30, ""),
                Tuple.Create<Int32, String>(10, "D"),
                Tuple.Create<Int32, String>(5, "")
            };
            var turn = CreateTurnWith(new FakeDiceDoublesRoller(rolls));
            turn.TakeFor(player.Id);
            Assert.That(player.LocationIndex, Is.EqualTo(10));

            turn.TakeFor(player.Id);
            Assert.That(player.LocationIndex, Is.EqualTo(20));
            Assert.That(player.Balance, Is.EqualTo(2000));
        }

        [Test]
        public void TestPlayer2ndTurnInJailRollsDoublesAndGetsOutOfJail()
        {
            var rolls = new Tuple<Int32, String>[]
            {
                Tuple.Create<Int32, String>(30, ""),
                Tuple.Create<Int32, String>(5, ""),
                Tuple.Create<Int32, String>(10, "D"),
                Tuple.Create<Int32, String>(5, "")
            };
            var turn = CreateTurnWith(new FakeDiceDoublesRoller(rolls));
            turn.TakeFor(player.Id);
            turn.TakeFor(player.Id);
            turn.TakeFor(player.Id);

            Assert.That(player.LocationIndex, Is.EqualTo(20));
            Assert.That(player.Balance, Is.EqualTo(2000));
        }

        [Test]
        public void TestPlayer3rdTurnInJailRollsDoubleAndGetsOutOfJail()
        {
            var rolls = new Tuple<Int32, String>[]
            {
                Tuple.Create<Int32, String>(30, ""),
                Tuple.Create<Int32, String>(5, ""),
                Tuple.Create<Int32, String>(10, ""),
                Tuple.Create<Int32, String>(10, "D"),
                Tuple.Create<Int32, String>(10, ""),
            };
            var turn = CreateTurnWith(new FakeDiceDoublesRoller(rolls));
            turn.TakeFor(player.Id);
            turn.TakeFor(player.Id);
            turn.TakeFor(player.Id);
            turn.TakeFor(player.Id);
            
            Assert.That(player.LocationIndex, Is.EqualTo(20));
            Assert.That(player.Balance, Is.EqualTo(2000));
        }

        [Test]
        public void TestInmateDoesNotRollDoublesOnFirstTurnInJailAndStaysInJail()
        {
            PlayerTakesTurnRollingA(30);
            PlayerTakesTurnRollingA(10);

            Assert.That(player.LocationIndex, Is.EqualTo(10));
        }
        
        private void PlayerTakesTurnRollingA(Int32 roll)
        {
            var fakeDice = new FakeDice();
            fakeDice.NextRoll = roll;
            var turn = CreateTurnWith(fakeDice);
            turn.TakeFor(player.Id);
        }

        [Test]
        public void TestPlayerDoesNotRollDoublesOnFirstOrSecondTurnInJailAndStaysInJail()
        {
            PlayerTakesTurnRollingA(30);
            PlayerTakesTurnRollingA(10);
            PlayerTakesTurnRollingA(10);

            Assert.That(player.LocationIndex, Is.EqualTo(10));
        }

        [Test]
        public void TestPlayerTakesThreeTurnsWithoutDoublesAndPays50ToGetOutOfJail()
        {
            PlayerTakesTurnRollingA(30);
            PlayerTakesTurnRollingA(10);
            PlayerTakesTurnRollingA(10);
            PlayerTakesTurnRollingA(10);

            Assert.That(player.LocationIndex, Is.EqualTo(20));
            Assert.That(player.Balance, Is.EqualTo(1950));
        }

        //[Test]
        //public void TestPlayerInJailPays50RollsDoublesAndRollsAgainGetsPlayerOutOfJail()
        //{
        //    var rolls = new Tuple<Int32, String>[]
        //    {
        //        Tuple.Create<Int32, String>(30, ""),
        //        Tuple.Create<Int32, String>(10, "D"),
        //        Tuple.Create<Int32, String>(4, "")
        //    };
        //    var doubleDice = new FakeDiceDoublesRoller(rolls);
        //    var turn = CreateTurnWith(new FakeDiceDoublesRoller(rolls));
        //    turn.TakeFor(player.Id);
        //    turn.TakeFor(player.Id);

        //    Assert.That(player.Balance, Is.EqualTo(1750));
        //    Assert.That(player.Location.Index, Is.EqualTo(25));
        //}

        //[Test]
        //public void TestPlayerInJailPays50RollsNonDoublesGetsOutOfJail()
        //{
        //    PlayerTakesTurnRollingA(30);
        //    PlayerTakesTurnRollingA(10);

        //    Assert.That(player.Balance, Is.EqualTo(1950));
        //    Assert.That(player.Location.Index, Is.EqualTo(20));
        //}
    }
}
