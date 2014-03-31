using System;
using Monopoly.Banker;
using Monopoly.Dice;
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
    public class NormalTurnTests
    {
        private IPlayer player;
        private TraditionalBanker banker;
        private TraditionalJailRoster jailRoster;
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
        }

        [Test]
        public void TestPlayerOn0Rolls7AndMovesTo7()
        {
            PlayerTakesTurnRollingA(7);

            Assert.That(locationManager.GetLocationIndexFor(player.Id), Is.EqualTo(7));
        }

        private void PlayerTakesTurnRollingA(Int32 roll)
        {
            dice = new FakeDice(new[] { new FakeRoll(roll, 0) });
            var turn = new NormalTurn(player.Id, dice, jailRoster, locationManager);
            turn.Take();
        }

        [Test]
        public void TestPlayerOn39Rolls6AndEndsUpOn5()
        {
            PlayerTakesTurnRollingA(39);
            PlayerTakesTurnRollingA(6);

            Assert.That(locationManager.GetLocationIndexFor(player.Id), Is.EqualTo(5));
        }

        [Test]
        public void TestPlayerPassesGoTwiceWithOneTurnAndBalanceIncreases400()
        {
            PlayerTakesTurnRollingA(80);

            Assert.That(banker.GetBalanceFor(player.Id), Is.EqualTo(1900));
        }

        [Test]
        public void TestBalanceDoesNotIncreaseForNonGoLocations()
        {
            var previousBalance = banker.GetBalanceFor(player.Id);
            PlayerTakesTurnRollingA(5);

            Assert.That(banker.GetBalanceFor(player.Id) <= previousBalance, Is.True);
        }

        [Test]
        public void TestPassGoToJailButNotStartDoesNotChangeBalance()
        {
            PlayerTakesTurnRollingA(33);

            Assert.That(locationManager.GetLocationIndexFor(player.Id), Is.EqualTo(33));
            Assert.That(banker.GetBalanceFor(player.Id), Is.EqualTo(1500));
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
            Assert.That(banker.GetBalanceFor(player.Id), Is.EqualTo(1400));
            Assert.That(locationManager.GetLocationIndexFor(player.Id), Is.EqualTo(10));
        }

        private Turn CreateTurnWith(IDice dice)
        {
            var locationFactory = new TraditionalLocationFactory(banker, dice, jailRoster, locationManager);
            locationManager.SetLocations(locationFactory.GetLocations());
            return new NormalTurn(player.Id, dice, jailRoster, locationManager);
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
            Assert.That(banker.GetBalanceFor(player.Id), Is.EqualTo(1220));
            Assert.That(locationManager.GetLocationIndexFor(player.Id), Is.EqualTo(20));
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
            Assert.That(banker.GetBalanceFor(player.Id), Is.EqualTo(1220));
            Assert.That(locationManager.GetLocationIndexFor(player.Id), Is.EqualTo(10));
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

            Assert.That(banker.GetBalanceFor(player.Id), Is.EqualTo(1500));
            Assert.That(locationManager.GetLocationIndexFor(player.Id), Is.EqualTo(10));
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

            Assert.That(banker.GetBalanceFor(player.Id), Is.EqualTo(1625));
            Assert.That(locationManager.GetLocationIndexFor(player.Id), Is.EqualTo(10));
        }

        [Test]
        public void TestPlayerThrowsNonDoublesLandsOnGoToJailWithBalanceNotChangingAndTurnIsOver()
        {
            var fakeDice = new FakeDice(new [] { new FakeRoll(30, 0) });
            var turn = CreateTurnWith(fakeDice);
            turn.Take();

            Assert.That(banker.GetBalanceFor(player.Id), Is.EqualTo(1500));
            Assert.That(locationManager.GetLocationIndexFor(player.Id), Is.EqualTo(10));
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

            Assert.That(banker.GetBalanceFor(player.Id), Is.EqualTo(1500));
            Assert.That(locationManager.GetLocationIndexFor(player.Id), Is.EqualTo(10));
        }
    }
}
