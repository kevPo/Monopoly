using System.Collections.Generic;
using Monopoly.Banker;
using Monopoly.Board;
using Monopoly.Cards;
using Monopoly.Cards.Commands;
using Monopoly.JailRoster;
using Monopoly.Locations.Defaults;
using Monopoly.Locations.Factories;
using MonopolyTests.Fakes;
using NUnit.Framework;

namespace MonopolyTests.LocationTests.DefaultsTests
{
    [TestFixture]
    public class CardDrawTests
    {
        private CardDraw communityChest;
        private TraditionalBanker banker;
        private TraditionalJailRoster jailRoster;
        private IBoard board;

        [SetUp]
        public void SetUp()
        {
            banker = new TraditionalBanker(new[] { 0 });
            jailRoster = new TraditionalJailRoster(banker);
            board = new GameBoard(banker);
            var dice = new FakeDice();
            var cardDeckFactory = new FakeCardDeckFactory(CreateCards());
            communityChest = new CardDraw(0, "Community Chest", banker, cardDeckFactory.GetCommunityChestDeck());
            var traditionalLocationFactory = 
                new TraditionalLocationFactory(banker, dice, jailRoster, board, cardDeckFactory);
            board.SetLocations(traditionalLocationFactory.GetLocations(), traditionalLocationFactory.GetRailroads(), traditionalLocationFactory.GetUtilities());
        }

        private IEnumerable<ICard> CreateCards()
        {
            var goToJailCard = new Card(new GoDirectlyToJailCommand(jailRoster, board));
            var collectMoneyCard = new Card(new CollectMoneyCommand(banker, 50));
            var cards = new[] { goToJailCard, collectMoneyCard };
            
            return cards;
        }

        [Test]
        public void TestPlayerPassesOverCommunityChestAndNothingHappens()
        {
            board.MovePlayer(0, 10);

            Assert.That(banker.GetBalanceFor(0), Is.EqualTo(1500));
            Assert.That(board.GetLocationIndexFor(0), Is.EqualTo(10));
        }

        [Test]
        public void TestPlayerLandsOnPicksTopCardAndPlaysThenPutsOnBottomOfDeck()
        {
            communityChest.LandedOnBy(0);

            Assert.That(jailRoster.IsInJail(0), Is.True);
            Assert.That(banker.GetBalanceFor(0), Is.EqualTo(1500));

            communityChest.LandedOnBy(0);
            Assert.That(banker.GetBalanceFor(0), Is.EqualTo(1550));
        }
    }
}
