using System;
using System.Collections.Generic;
using Monopoly.Banker;
using Monopoly.Board;
using Monopoly.Cards;
using Monopoly.Cards.Commands;
using Monopoly.Dice;
using Monopoly.JailRoster;
using Monopoly.Locations.Factories;
using Monopoly.Turns;
using MonopolyTests.Fakes;
using NUnit.Framework;

namespace MonopolyTests.TurnsTests
{
    [TestFixture]
    public class NormalTurnTests
    {
        private Int32 playerId;
        private TraditionalBanker banker;
        private TraditionalJailRoster jailRoster;
        private GameBoard board;
        private FakeDice dice;
        private CardDeckFactory cardDeckFactory;

        [SetUp]
        public void SetUp()
        {
            playerId = 0;
            banker = new TraditionalBanker(new[] { playerId });
            jailRoster = new TraditionalJailRoster(banker);
            board = new GameBoard();
            cardDeckFactory = new FakeCardDeckFactory(CreateCards());
            var locationFactory = new TraditionalLocationFactory(banker, dice, jailRoster, board, cardDeckFactory);
            board.SetLocations(locationFactory.GetLocations(), locationFactory.GetRailroads(), locationFactory.GetUtilities());
        }

        private IEnumerable<ICard> CreateCards()
        {
            return new[]
                {
                    new Card(new CollectMoneyCommand(banker, 100)),
                    new Card(new GoDirectlyToJailCommand(jailRoster, board))
                };
        }

        [Test]
        public void TestPlayerOn0RollsTenAndMovesToTen()
        {
            PlayerTakesTurnRollingA(10);

            Assert.That(board.GetLocationIndexFor(playerId), Is.EqualTo(10));
        }

        private void PlayerTakesTurnRollingA(Int32 roll)
        {
            dice = new FakeDice(new[] { new FakeRoll(roll, 0) });
            var turn = new NormalTurn(playerId, dice, jailRoster, board);
            turn.Take();
        }

        [Test]
        public void TestPlayerOn39Rolls6AndEndsUpOn5()
        {
            PlayerTakesTurnRollingA(39);
            PlayerTakesTurnRollingA(6);

            Assert.That(board.GetLocationIndexFor(playerId), Is.EqualTo(5));
        }

        [Test]
        public void TestPlayerPassesGoTwiceWithOneTurnAndBalanceIncreases400()
        {
            PlayerTakesTurnRollingA(80);

            Assert.That(banker.GetBalanceFor(playerId), Is.EqualTo(1900));
        }

        [Test]
        public void TestBalanceDoesNotIncreaseForNonGoLocations()
        {
            var previousBalance = banker.GetBalanceFor(playerId);
            PlayerTakesTurnRollingA(5);

            Assert.That(banker.GetBalanceFor(playerId) <= previousBalance, Is.True);
        }

        [Test]
        public void TestPassGoToJailButNotStartDoesNotChangeBalance()
        {
            // Player buys location 35 for 200
            PlayerTakesTurnRollingA(35);

            Assert.That(board.GetLocationIndexFor(playerId), Is.EqualTo(35));
            Assert.That(banker.GetBalanceFor(playerId), Is.EqualTo(1300));
        }

        [Test]
        public void TestDouble6AndNonDouble4LandsPlayerOn10InOneTurn()
        {
            var rolls = new[]
                    {
                        new FakeRoll(3, 3),
                        new FakeRoll(3, 1)
                    };
            var turn = CreateTurnWith(new FakeDice(rolls));
            turn.Take();

           Assert.That(board.GetLocationIndexFor(playerId), Is.EqualTo(10));
        }

        private Turn CreateTurnWith(IDice dice)
        {
            var locationFactory = new TraditionalLocationFactory(banker, dice, jailRoster, board, cardDeckFactory);
            board.SetLocations(locationFactory.GetLocations(), locationFactory.GetRailroads(), locationFactory.GetUtilities());
            return new NormalTurn(playerId, dice, jailRoster, board);
        }

        [Test]
        public void TestDoublesThrownTwiceAndPlayerLandsOnThreeLocations()
        {
            var rolls = new[]
                    {
                        new FakeRoll(3, 3),
                        new FakeRoll(5, 5),
                        new FakeRoll(3, 1)
                    };
            var turn = CreateTurnWith(new FakeDice(rolls));
            turn.Take();

            Assert.That(board.GetLocationIndexFor(playerId), Is.EqualTo(20));
        }

        [Test]
        public void TestDoublesThrownThreeTimesAndPlayerLandsOnJustVisiting()
        {
            var rolls = new[]
                    {
                        new FakeRoll(3, 3),
                        new FakeRoll(5, 5),
                        new FakeRoll(6, 6),
                        new FakeRoll(3, 1)
                    };
            var turn = CreateTurnWith(new FakeDice(rolls));
            turn.Take();

            Assert.That(board.GetLocationIndexFor(playerId), Is.EqualTo(10));
        }

        [Test]
        public void RollDoubles3TimesWithoutPassingGoPutsPlayerInJailWithoutCollectingSalary()
        {
            var rolls = new[]
                    {
                        new FakeRoll(5, 5),
                        new FakeRoll(5, 5),
                        new FakeRoll(3, 3),
                        new FakeRoll(3, 1)
                    };
            var turn = CreateTurnWith(new FakeDice(rolls));
            turn.Take();

            Assert.That(banker.GetBalanceFor(playerId), Is.EqualTo(1500));
            Assert.That(board.GetLocationIndexFor(playerId), Is.EqualTo(10));
        }

        [Test]
        public void RollDoubles3TimesPassingGoAndCollectingSalaryPutsPlayerInJailWithSalary()
        {
            var rolls = new[]
                    {
                        new FakeRoll(19, 19),
                        new FakeRoll(6, 6),
                        new FakeRoll(5, 5),
                        new FakeRoll(3, 1)
                    };
            var turn = CreateTurnWith(new FakeDice(rolls));
            turn.Take();

            Assert.That(banker.GetBalanceFor(playerId), Is.EqualTo(1625));
            Assert.That(board.GetLocationIndexFor(playerId), Is.EqualTo(10));
        }

        [Test]
        public void TestPlayerThrowsNonDoublesLandsOnGoToJailWithBalanceNotChangingAndTurnIsOver()
        {
            var fakeDice = new FakeDice(new [] { new FakeRoll(30, 0) });
            var turn = CreateTurnWith(fakeDice);
            turn.Take();

            Assert.That(banker.GetBalanceFor(playerId), Is.EqualTo(1500));
            Assert.That(board.GetLocationIndexFor(playerId), Is.EqualTo(10));
        }

        [Test]
        public void TestPlayerRollsDoublesLandsOnGoToJailTurnIsOverAndBalanceNotChanged()
        {
            var rolls = new[]
                    {
                        new FakeRoll(15, 15),
                        new FakeRoll(3, 1)
                    };
            var turn = CreateTurnWith(new FakeDice(rolls));
            turn.Take();

            Assert.That(banker.GetBalanceFor(playerId), Is.EqualTo(1500));
            Assert.That(board.GetLocationIndexFor(playerId), Is.EqualTo(10));
        }

        [Test]
        public void TestPlayerRollsNonDoubleOnCommunityChestAndCardsEffectHappensOnPlayer()
        {
            var rolls = new[]
                    {
                        new FakeRoll(2, 15),
                        new FakeRoll(3, 1)
                    };
            var turn = CreateTurnWith(new FakeDice(rolls));
            turn.Take();

            Assert.That(board.GetLocationIndexFor(playerId), Is.EqualTo(17));
            Assert.That(banker.GetBalanceFor(playerId), Is.EqualTo(1600));
        }

        [Test]
        public void TestPlayerRollsDoublesOnCommunityChestAndCardsEffectHappensOnPlayerThenHeRollsAgain()
        {
            var rolls = new[]
                    {
                        new FakeRoll(1, 1),
                        new FakeRoll(5, 3)
                    };
            var turn = CreateTurnWith(new FakeDice(rolls));
            turn.Take();

            Assert.That(banker.GetBalanceFor(playerId), Is.EqualTo(1600));
            Assert.That(board.GetLocationIndexFor(playerId), Is.EqualTo(10));
        }

        [Test]
        public void TestPlayerRollsDoublesOnCommunityChestGoingToJailAndDoesNotRollAgain()
        {
            var rolls = new[]
                    {
                        new FakeRoll(1, 1),
                        new FakeRoll(3, 2)
                    };
            var cards = new[]
                    {
                        new Card(new GoDirectlyToJailCommand(jailRoster, board)),
                        new Card(new CollectMoneyCommand(banker, 100))
                    };
            var turn = CreateTurnWithSpecificCards(new FakeDice(rolls), cards);
            turn.Take();

            Assert.That(banker.GetBalanceFor(playerId), Is.EqualTo(1500));
            Assert.That(jailRoster.IsInJail(playerId), Is.True);
            Assert.That(board.GetLocationIndexFor(playerId), Is.EqualTo(10));
        }

        private Turn CreateTurnWithSpecificCards(IDice dice, IEnumerable<ICard> cards)
        {
            cardDeckFactory = new FakeCardDeckFactory(cards);
            var locationFactory = new TraditionalLocationFactory(banker, dice, jailRoster, board, cardDeckFactory);
            board.SetLocations(locationFactory.GetLocations(), locationFactory.GetRailroads(), locationFactory.GetUtilities());
            return new NormalTurn(playerId, dice, jailRoster, board);
        }
    }
}
