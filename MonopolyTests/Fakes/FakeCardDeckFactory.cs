using System.Collections.Generic;
using Monopoly.Cards;

namespace MonopolyTests.Fakes
{
    public class FakeCardDeckFactory : CardDeckFactory
    {
        private IEnumerable<ICard> cards;

        public FakeCardDeckFactory(IEnumerable<ICard> cards)
        {
            this.cards = cards;
        }

        public override CardDeck GetCommunityChestDeck()
        {
            return new CardDeck(cards);
        }

        public override CardDeck GetChanceDeck()
        {
            return new CardDeck(cards);
        }
    }
}
