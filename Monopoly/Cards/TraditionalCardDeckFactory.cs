using Monopoly.Banker;
using Monopoly.Board;
using Monopoly.Dice;
using Monopoly.JailRoster;
namespace Monopoly.Cards
{
    public class TraditionalCardDeckFactory : CardDeckFactory
    {
        private CommunityChestFactory communityChestFactory;
        private ChanceFactory chanceFactory;

        public TraditionalCardDeckFactory(IBanker banker, IJailRoster jailRoster,
            GameBoard board, IDice dice)
        {
            this.communityChestFactory = new CommunityChestFactory(banker, jailRoster, board);
            this.chanceFactory = new ChanceFactory(banker, jailRoster, board, dice);
        }

        public override CardDeck GetCommunityChestDeck()
        {
            return new CardDeck(communityChestFactory.GetCards());
        }

        public override CardDeck GetChanceDeck()
        {
            return new CardDeck(chanceFactory.GetCards());
        }
    }
}
