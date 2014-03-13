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
            var boardBuilder = new TraditionalBoardBuilder(dice);
            boardBuilder.Build();
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

        [Test]
        public void TestPlayerOn0Rolls7AndMovesTo7()
        {
            dice.NextRoll = 7;
            board.TakeTurnFor(player);
            Assert.That(player.Location.Index, Is.EqualTo(7));
        }

        [Test]
        public void TestPlayerOn39Rolls6AndEndsUpOn5()
        {
            dice.NextRoll = 39;
            board.TakeTurnFor(player);
            dice.NextRoll = 6;
            board.TakeTurnFor(player);
            Assert.That(player.Location.Index, Is.EqualTo(5));
        }

        [Test]
        public void TestPlayerPassesGoTwiceWithOneTurnAndBalanceIncreases400()
        {
            dice.NextRoll = 80;
            board.TakeTurnFor(player);
            Assert.That(player.Balance, Is.EqualTo(2400));
        }

        [Test]
        public void TestBalanceDoesNotIncreaseForNonGoLocations()
        {
            var previousBalance = player.Balance;
            dice.NextRoll = 5;
            board.TakeTurnFor(player);
            Assert.That(player.Balance <= previousBalance, Is.True);
        }

        [Test]
        public void TestOnGoUpdateLocationWithoutMovingAndBalanceDoesNotChange()
        {
            dice.NextRoll = 0;
            board.TakeTurnFor(player);
            Assert.That(player.Balance, Is.EqualTo(2000));
        }

        [Test]
        public void TestPassGoToJailButNotStartDoesNotChangeBalance()
        {
            dice.NextRoll = 33;
            board.TakeTurnFor(player);
            Assert.That(player.Location.Index, Is.EqualTo(33));
            Assert.That(player.Balance, Is.EqualTo(2000));
        }

        [Test]
        public void TestPlayerPassesOverIncomeTaxAndNothingHappens()
        {
            dice.NextRoll = 7;
            board.TakeTurnFor(player);
            Assert.That(player.Balance, Is.EqualTo(2000));
        }

        [Test]
        public void TestPlayerPassesOverLuxuryTaxAndBalanceStaysTheSame()
        {
            dice.NextRoll = 39;
            board.TakeTurnFor(player);
            //buys boardwalk so balance decreases 400
            Assert.That(player.Balance, Is.EqualTo(1600));
        }

        [Test]
        public void TestPlayerLandsOnOwnedUtilityAndPlayerPaysOwner4TimesDice()
        {
            var player2 = new Player("car", 2000);
            player2.LandedOn(board.GetStartingLocation());
            dice.NextRoll = 12;
            board.TakeTurnFor(player);
            dice.NextRoll = 12;
            board.TakeTurnFor(player2);

            Assert.That(player2.Balance, Is.EqualTo(1952));
            Assert.That(player.Balance, Is.EqualTo(1898));
        }
    }
}
