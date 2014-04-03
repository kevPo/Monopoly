using System.Collections.Generic;

namespace Monopoly.Cards
{
    public class CardDeck
    {
        protected Queue<ICard> cards;

        public CardDeck(IEnumerable<ICard> cards)
        {
            this.cards = new Queue<ICard>(cards);
        }

        public ICard PickupCard()
        {
            return cards.Dequeue();
        }

        public void PlaceCardOnBottom(ICard card)
        { 
            cards.Enqueue(card);
        }
    }
}
