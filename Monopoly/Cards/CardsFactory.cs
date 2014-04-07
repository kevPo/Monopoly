using System;
using System.Collections.Generic;

namespace Monopoly.Cards
{
    public class CardsFactory
    {
        private const Int32 maximumDeckSize = 16;
        private List<ICard> cards;

        public CardsFactory()
        {
            cards = new List<ICard>();
        }

        public void AddCard(ICard card)
        {
            if (cards.Count < maximumDeckSize)
                cards.Add(card);
        }

        public IEnumerable<ICard> GetCards()
        {
            cards.Shuffle();

            return cards;
        }
    }
}
