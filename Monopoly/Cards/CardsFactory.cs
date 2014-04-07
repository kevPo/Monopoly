using System.Collections.Generic;

namespace Monopoly.Cards
{
    public abstract class CardsFactory
    {
        public IEnumerable<ICard> GetCards()
        {
            var cards = CreateCards();
            cards = cards.Shuffle();

            return cards;
        }

        protected abstract List<ICard> CreateCards();
    }
}
