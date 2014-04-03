namespace Monopoly.Cards
{
    public abstract class CardDeckFactory
    {
        public abstract CardDeck GetCommunityChestDeck();
        public abstract CardDeck GetChanceDeck();
    }
}
