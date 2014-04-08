using System;
using System.Collections.Generic;
using Monopoly.Banker;
using Monopoly.Board;
using Monopoly.JailRoster;
using Monopoly.Turns;
using MonopolyTests.Fakes;
using NUnit.Framework;

namespace MonopolyTests.TurnsTests
{
    [TestFixture]
    public class InmateTurnTests
    {
        private TraditionalJailRoster jailRoster;
        private TraditionalBanker banker;
        private GameBoard gameBoard;
        private FakeDice dice;

        [SetUp]
        public void SetUp()
        {
            var faker = new MotherFaker();
            jailRoster = faker.JailRoster;
            banker = faker.Banker;
            gameBoard = faker.GameBoard;
            dice = faker.Dice;
            PutPlayerInJail();
        }

        private void PutPlayerInJail()
        {
            jailRoster.Add(0);
            gameBoard.SendPlayerDirectlyTo(0, 10);
        }

        [Test]
        public void TestInmateRollsDoublesAndGetsOutOfJailButDoesNotMoveAgain()
        {
            var rolls = new[]
                    {
                        new FakeRoll(5, 5),
                        new FakeRoll(2, 3)
                    };
            var turn = CreateTurnWith(rolls);

            turn.Take();
            Assert.That(gameBoard.GetLocationIndexFor(0), Is.EqualTo(20));
            Assert.That(banker.GetBalanceFor(0), Is.EqualTo(1500));
        }

        private Turn CreateTurnWith(IEnumerable<FakeRoll> rolls)
        {
            dice.SetRolls(rolls);
            
            return new InmateTurn(0, dice, jailRoster, gameBoard);
        }

        [Test]
        public void TestInmateSecondTurnInJailRollsDoublesAndGetsOutOfJail()
        {
            var rolls = new []
                    {
                        new FakeRoll(2, 3),
                        new FakeRoll(5, 5),
                        new FakeRoll(2, 3)
                    };
            var turn = CreateTurnWith(rolls);
            turn.Take();
            turn.Take();

            Assert.That(gameBoard.GetLocationIndexFor(0), Is.EqualTo(20));
            Assert.That(banker.GetBalanceFor(0), Is.EqualTo(1500));
        }

        [Test]
        public void TestInmateThirdTurnInJailRollsDoubleAndGetsOutOfJail()
        {
            var rolls = new []
                    {
                        new FakeRoll(2, 3),
                        new FakeRoll(7, 3),
                        new FakeRoll(5, 5),
                        new FakeRoll(8, 2)
                    };
            var turn = CreateTurnWith(rolls);
            turn.Take();
            turn.Take();
            turn.Take();

            Assert.That(gameBoard.GetLocationIndexFor(0), Is.EqualTo(20));
            Assert.That(banker.GetBalanceFor(0), Is.EqualTo(1500));
        }

        [Test]
        public void TestInmateDoesNotRollDoublesOnFirstTurnInJailAndStaysInJail()
        {
            PlayerTakesTurnRollingA(10);

            Assert.That(gameBoard.GetLocationIndexFor(0), Is.EqualTo(10));
        }

        private void PlayerTakesTurnRollingA(Int32 roll)
        {
            var turn = CreateTurnWith(new[] { new FakeRoll(roll, 0) });
            turn.Take();
        }

        [Test]
        public void TestInmateDoesNotRollDoublesOnFirstOrSecondTurnAndStaysInJail()
        {
            PlayerTakesTurnRollingA(10);
            PlayerTakesTurnRollingA(10);

            Assert.That(gameBoard.GetLocationIndexFor(0), Is.EqualTo(10));
        }

        [Test]
        public void TestInmateTakesThreeTurnsWithoutDoublesAndPays50ToGetOutOfJail()
        {
            PlayerTakesTurnRollingA(10);
            PlayerTakesTurnRollingA(10);
            PlayerTakesTurnRollingA(10);

            Assert.That(gameBoard.GetLocationIndexFor(0), Is.EqualTo(20));
            Assert.That(banker.GetBalanceFor(0), Is.EqualTo(1450));
        }

        //[Test]
        //public void TestInmatePays50RollsDoublesAndRollsAgainGetsPlayerOutOfJail()
        //{
        //    var rolls = new []
        //    {
        //        new FakeRoll(5, 5),
        //        new FakeRoll(3, 1)
        //    };
        //    var doubleDice = new FakeDiceDoublesRoller(rolls);
        //    var turn = CreateTurnWith(new FakeDiceDoublesRoller(rolls));
        //    turn.Take();

        //    Assert.That(banker.GetBalanceFor(0), Is.EqualTo(1250));
        //    Assert.That(locationManager.GetLocationIndexFor(0), Is.EqualTo(25));
        //}

        //[Test]
        //public void TestInmatePays50RollsNonDoublesGetsOutOfJail()
        //{
        //    PlayerTakesTurnRollingA(10);

        //    Assert.That(banker.GetBalanceFor(0), Is.EqualTo(1450));
        //    Assert.That(locationManager.GetLocationIndexFor(0), Is.EqualTo(20));
        //}

    }
}
