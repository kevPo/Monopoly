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

        [SetUp]
        public void SetUp()
        {
            jailRoster = new TraditionalJailRoster();
            var boardFactory = new FakeTraditionalBoardFactory(new TraditionalDice(), new IPlayer[] { }, jailRoster);
            locations = boardFactory.GetTraditionalLocations();
            player = new Player("horse", 2000);
            player.LandedOn(0);
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
            var doubleDice = new FakeDiceDoublesRoller(rolls);
            var turn = new Turn(locations, jailRoster, player, doubleDice);
            turn.Take();

            // Player lands on Oriental Ave and buys it for $100 on first roll
            Assert.That(player.Balance, Is.EqualTo(1900));
            Assert.That(player.LocationIndex, Is.EqualTo(10));
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
            var doubleDice = new FakeDiceDoublesRoller(rolls);
            var turn = new Turn(locations, jailRoster, player, doubleDice);
            turn.Take();

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
            var doubleDice = new FakeDiceDoublesRoller(rolls);
            var turn = new Turn(locations, jailRoster, player, doubleDice);
            turn.Take();

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
            var doubleDice = new FakeDiceDoublesRoller(rolls);
            var turn = new Turn(locations, jailRoster, player, doubleDice);
            turn.Take();

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
            var doubleDice = new FakeDiceDoublesRoller(rolls);
            var turn = new Turn(locations, jailRoster, player, doubleDice);
            turn.Take();

            Assert.That(player.Balance, Is.EqualTo(2125));
            Assert.That(player.LocationIndex, Is.EqualTo(10));
        } 

        [Test]
        public void TestPlayerThrowsNonDoublesLandsOnGoToJailWithBalanceNotChangingAndTurnIsOver()
        {
            var dice = new FakeDice();
            var turn = new Turn(locations, jailRoster, player, dice);
            player.LandedOn(0);
            dice.NextRoll = 30;
            turn.Take();

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
            var doubleDice = new FakeDiceDoublesRoller(rolls);
            var turn = new Turn(locations, jailRoster, player, doubleDice);
            turn.Take();

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
            var doubleDice = new FakeDiceDoublesRoller(rolls);
            var turn = new Turn(locations, jailRoster, player, doubleDice);
            turn.Take();
            Assert.That(player.LocationIndex, Is.EqualTo(10));

            turn.Take();
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
            var doubleDice = new FakeDiceDoublesRoller(rolls);
            var turn = new Turn(locations, jailRoster, player, doubleDice);
            turn.Take();
            turn.Take();
            turn.Take();

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
            var doubleDice = new FakeDiceDoublesRoller(rolls);
            var turn = new Turn(locations, jailRoster, player, doubleDice);
            turn.Take();
            turn.Take();
            turn.Take();
            turn.Take();
            
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
            var dice = new FakeDice();
            var turn = new Turn(locations, jailRoster, player, dice);
            dice.NextRoll = roll;
            turn.Take();
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
        //    var turn = new Turn(locations, jailRoster, player, doubleDice);
        //    turn.Take();
        //    turn.Take();

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
