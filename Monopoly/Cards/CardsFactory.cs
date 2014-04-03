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
            ShuffleCards();

            return cards;
        }

        private void ShuffleCards()
        {
            var randomCardGenerator = new Random();
            var n = cards.Count;
            while (n > 1)
            {
                n--;
                var k = randomCardGenerator.Next(n + 1);
                var value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }
    }
}
