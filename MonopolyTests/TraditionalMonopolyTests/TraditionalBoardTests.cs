using System;
using Monopoly;
using Monopoly.Board;
using Monopoly.TraditionalMonopoly;
using MonopolyTests.Fakes;
using NUnit.Framework;

namespace MonopolyTests.TraditionalMonopolyTests
{
    [TestFixture]
    public class TraditionalBoardTests
    {
        private IBoard board;
        private IPlayer player;
        private FakeDice dice;

        [SetUp]
        public void SetUp()
        {
            dice = new FakeDice();
            var boardBuilder = new TraditionalBoardFactory(dice);
            boardBuilder.Create();
            board = boardBuilder.Board;
            player = new Player("horse", 2000);
            player.LandedOn(board.GetStartingLocation());
        }

        [Test]
        public void TestGetStartingPositionReturnsGo()
        {
            var go = board.GetStartingLocation();
            Assert.That(go.Name, Is.EqualTo("Go"));
            Assert.That(go.Index, Is.EqualTo(0));
        }

        private void RollDice(Int32 roll)
        {
            dice.NextRoll = roll;
        }

        [Test]
        public void TestPlayerOn0Rolls7AndMovesTo7()
        {
            RollDice(7);
            board.TakeTurnFor(player);
            Assert.That(player.Location.Index, Is.EqualTo(7));
        }

        [Test]
        public void TestPlayerOn39Rolls6AndEndsUpOn5()
        {
            RollDice(39);
            board.TakeTurnFor(player);
            RollDice(6);
            board.TakeTurnFor(player);
            Assert.That(player.Location.Index, Is.EqualTo(5));
        }

        [Test]
        public void TestPlayerPassesGoTwiceWithOneTurnAndBalanceIncreases400()
        {
            RollDice(80);
            board.TakeTurnFor(player);
            Assert.That(player.Balance, Is.EqualTo(2400));
        }

        [Test]
        public void TestBalanceDoesNotIncreaseForNonGoLocations()
        {
            var previousBalance = player.Balance;
            RollDice(5);
            board.TakeTurnFor(player);
            Assert.That(player.Balance <= previousBalance, Is.True);
        }

        [Test]
        public void TestOnGoUpdateLocationWithoutMovingAndBalanceDoesNotChange()
        {
            RollDice(0);
            board.TakeTurnFor(player);
            Assert.That(player.Balance, Is.EqualTo(2000));
        }

        [Test]
        public void TestPassGoToJailButNotStartDoesNotChangeBalance()
        {
            RollDice(33);
            board.TakeTurnFor(player);
            Assert.That(player.Location.Index, Is.EqualTo(33));
            Assert.That(player.Balance, Is.EqualTo(2000));
        }

        [Test]
        public void TestPlayerPassesOverIncomeTaxAndNothingHappens()
        {
            RollDice(7);
            board.TakeTurnFor(player);
            Assert.That(player.Balance, Is.EqualTo(2000));
        }

        [Test]
        public void TestPlayerPassesOverLuxuryTaxAndBalanceStaysTheSame()
        {
            RollDice(39);
            board.TakeTurnFor(player);
            //buys boardwalk so balance decreases 400
            Assert.That(player.Balance, Is.EqualTo(1600));
        }

        [Test]
        public void TestPlayerLandsOnOwnedUtilityAndPlayerPaysOwner4TimesDice()
        {
            var player2 = new Player("car", 2000);
            player2.LandedOn(board.GetStartingLocation());
            RollDice(12);
            board.TakeTurnFor(player);
            RollDice(12);
            board.TakeTurnFor(player2);

            Assert.That(player2.Balance, Is.EqualTo(1952));
            Assert.That(player.Balance, Is.EqualTo(1898));
        }

        [Test]
        public void TestIncomeTaxCharges10PercentIfBalanceLessThan2000()
        {
            var player = new Player("horse", 1500);
            InitializeAndMovePlayerToIncomeTax(player);
            Assert.That(player.Balance, Is.EqualTo(1350));
        }

        [Test]
        public void TestIncomeTaxCharges200IfBalanceGreaterThan2000()
        {
            var player = new Player("Horse", 2200);
            InitializeAndMovePlayerToIncomeTax(player);
            Assert.That(player.Balance, Is.EqualTo(2000));
        }

        [Test]
        public void TestIncomeTaxChargesNothingWhenBalanceIsZero()
        {
            var player = new Player("Horse", 0);
            InitializeAndMovePlayerToIncomeTax(player);
            Assert.That(player.Balance, Is.EqualTo(0));
        }

        [Test]
        public void TestIncomeTaxCharges200WhenBalanceIs2000()
        {
            var player = new Player("Horse", 2000);
            InitializeAndMovePlayerToIncomeTax(player);
            Assert.That(player.Balance, Is.EqualTo(1800));
        }

        private void InitializeAndMovePlayerToIncomeTax(Player player)
        {
            player.LandedOn(board.GetStartingLocation());
            RollDice(4);
            board.TakeTurnFor(player);
        }

        [Test]
        public void TestLuxuryTaxCharges75Dollars()
        {
            var player = new Player("horse", 100);
            player.LandedOn(board.GetStartingLocation());
            RollDice(38);
            board.TakeTurnFor(player);
            Assert.That(player.Balance, Is.EqualTo(25));
        }

        [Test]
        public void TestDouble6AndNonDouble4LandsPlayerOn10InOneTurn()
        {
            var doubleDice = new FakeDiceDoublesRoller(new Int32[] {6}, 4);
            var boardBuilder = new TraditionalBoardFactory(doubleDice);
            boardBuilder.Create();
            board = boardBuilder.Board;
            var horse = new Player("horse", 2000);
            horse.LandedOn(board.GetStartingLocation());

            board.TakeTurnFor(horse);
            // Player lands on Oriental Ave and buys it for $100 on first roll
            Assert.That(horse.Balance, Is.EqualTo(1900));  
            Assert.That(horse.Location.Index, Is.EqualTo(10));
        }

        [Test]
        public void TestDoublesThrownTwiceAndPlayerLandsOnThreeLocations()
        {
            var doubleDice = new FakeDiceDoublesRoller(new Int32[] { 6, 10 }, 4);
            var boardBuilder = new TraditionalBoardFactory(doubleDice);
            boardBuilder.Create();
            board = boardBuilder.Board;
            var horse = new Player("horse", 2000);
            horse.LandedOn(board.GetStartingLocation());

            board.TakeTurnFor(horse);
            // Player should land on and buy Oriental (6) for $100
            // and St. James (16) for $180.
            Assert.That(horse.Balance, Is.EqualTo(1720));
            Assert.That(horse.Location.Index, Is.EqualTo(20));
        }

        [Test]
        public void TestDoublesThrownThreeTimesAndPlayerLandsOnJustVisiting()
        {
            var doubleDice = new FakeDiceDoublesRoller(new Int32[] { 6, 10, 12 }, 4);
            var boardBuilder = new TraditionalBoardFactory(doubleDice);
            boardBuilder.Create();
            board = boardBuilder.Board;
            var horse = new Player("horse", 2000);
            horse.LandedOn(board.GetStartingLocation());

            board.TakeTurnFor(horse);
            // Player should land on and buy Oriental (6) for $100
            // and St. James (16) for $180.
            Assert.That(horse.Balance, Is.EqualTo(1720));
            Assert.That(horse.Location.Index, Is.EqualTo(10));
        }
    }
}
