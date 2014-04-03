using System.Linq;
using Monopoly.Banker;
using Monopoly.Board;
using Monopoly.Cards.Commands;
using Monopoly.JailRoster;

namespace Monopoly.Cards
{
    public class CommunityChestFactory : CardsFactory
    {
        private IBanker banker;
        private IJailRoster jailRoster;
        private GameBoard board;

        public CommunityChestFactory(IBanker banker, IJailRoster jailRoster, GameBoard board)
        {
            this.banker = banker;
            this.jailRoster = jailRoster;
            this.board = board;
            CreateDeck();
        }

        private void CreateDeck()
        {
            var locations = board.GetLocations();
            AddCard(new Card(new CollectMoneyCommand(banker, 100)));
            AddCard(new Card(new CollectMoneyCommand(banker, 100)));
            AddCard(new Card(new CollectMoneyCommand(banker, 45)));
            AddCard(new Card(new CollectMoneyCommand(banker, 200)));
            AddCard(new Card(new PayMoneyCommand(banker, 100)));
            AddCard(new Card(new PayMoneyCommand(banker, 50)));
            AddCard(new Card(new GetOutOfJailFreeCommand(jailRoster)));
            AddCard(new Card(new CollectMoneyCommand(banker, 25)));
            AddCard(new Card(new PayMoneyCommand(banker, 150)));
            AddCard(new Card(new AdvanceTokenCommand(0, board)));
            AddCard(new Card(new CollectMoneyCommand(banker, 10)));
            AddCard(new Card(new CollectMoneyFromAllPlayersCommand(banker, 50)));
            AddCard(new Card(new CollectMoneyCommand(banker, 20)));
            AddCard(new Card(new PropertyRepairCommand(banker, 40, 115)));
            AddCard(new Card(new CollectMoneyCommand(banker, 100)));
            AddCard(new Card(new GoDirectlyToJailCommand(jailRoster, board)));
        }
    }
}
