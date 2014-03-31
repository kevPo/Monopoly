using System;
using System.Collections.Generic;
using Monopoly.Banker;
using Monopoly.JailRoster;
using Monopoly.Locations.Factories;
using Monopoly.Locations.Managers;
using Monopoly.Players;
using Monopoly.Turns;
using MonopolyTests.Fakes;
using NUnit.Framework;

namespace MonopolyTests.TurnsTests
{
    [TestFixture]
    public class InmateTurnTests
    {
        private IPlayer player;
        private TraditionalJailRoster jailRoster;
        private TraditionalBanker banker;
        private LocationManager locationManager;
        private FakeDice dice;

        [SetUp]
        public void SetUp()
        {
            player = new Player(0, "horse");
            banker = new TraditionalBanker(new[] { player.Id });
            jailRoster = new TraditionalJailRoster(banker);
            locationManager = new LocationManager();
            var locationFactory = new TraditionalLocationFactory(banker, dice, jailRoster, locationManager);
            locationManager.SetLocations(locationFactory.GetLocations());
            dice = new FakeDice();
            PutPlayerInJail();
        }

        private void PutPlayerInJail()
        {
            jailRoster.Add(player.Id);
            locationManager.SetLocationIndexFor(player.Id, 10);
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
            Assert.That(locationManager.GetLocationIndexFor(player.Id), Is.EqualTo(20));
            Assert.That(banker.GetBalanceFor(player.Id), Is.EqualTo(1500));
        }

        private Turn CreateTurnWith(IEnumerable<FakeRoll> rolls)
        {
            dice.SetRolls(rolls);
            
            return new InmateTurn(player.Id, dice, jailRoster, locationManager);
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

            Assert.That(locationManager.GetLocationIndexFor(player.Id), Is.EqualTo(20));
            Assert.That(banker.GetBalanceFor(player.Id), Is.EqualTo(1500));
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

            Assert.That(locationManager.GetLocationIndexFor(player.Id), Is.EqualTo(20));
            Assert.That(banker.GetBalanceFor(player.Id), Is.EqualTo(1500));
        }

        [Test]
        public void TestInmateDoesNotRollDoublesOnFirstTurnInJailAndStaysInJail()
        {
            PlayerTakesTurnRollingA(10);

            Assert.That(locationManager.GetLocationIndexFor(player.Id), Is.EqualTo(10));
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

            Assert.That(locationManager.GetLocationIndexFor(player.Id), Is.EqualTo(10));
        }

        [Test]
        public void TestInmateTakesThreeTurnsWithoutDoublesAndPays50ToGetOutOfJail()
        {
            PlayerTakesTurnRollingA(10);
            PlayerTakesTurnRollingA(10);
            PlayerTakesTurnRollingA(10);

            Assert.That(locationManager.GetLocationIndexFor(player.Id), Is.EqualTo(20));
            Assert.That(banker.GetBalanceFor(player.Id), Is.EqualTo(1450));
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

        //    Assert.That(banker.GetBalanceFor(player.Id), Is.EqualTo(1250));
        //    Assert.That(locationManager.GetLocationIndexFor(player.Id), Is.EqualTo(25));
        //}

        //[Test]
        //public void TestInmatePays50RollsNonDoublesGetsOutOfJail()
        //{
        //    PlayerTakesTurnRollingA(10);

        //    Assert.That(banker.GetBalanceFor(player.Id), Is.EqualTo(1450));
        //    Assert.That(locationManager.GetLocationIndexFor(player.Id), Is.EqualTo(20));
        //}

    }
}
