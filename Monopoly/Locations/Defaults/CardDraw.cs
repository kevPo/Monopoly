using System;
using Monopoly.Banker;
using Monopoly.Cards;

namespace Monopoly.Locations.Defaults
{
    public class CardDraw : Location
    {
        private CardDeck cardDeck;

        public CardDraw(Int32 index, String name, IBanker banker, CardDeck cardDeck)
            : base(index, name, banker)
        {
            this.cardDeck = cardDeck;
        }

        public override void LandedOnBy(Int32 playerId)
        {
            var card = cardDeck.PickupCard();
            card.InvokeActionFor(playerId);
            cardDeck.PlaceCardOnBottom(card);
        }
    }
}
