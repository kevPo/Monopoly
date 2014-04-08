using System.Collections.Generic;
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
        }

        protected override List<ICard> CreateCards()
        {
            var locations = board.Locations;

            var cards = new ICard[]
            {
                new Card(new CollectMoneyCommand(banker, 100)),
                new Card(new CollectMoneyCommand(banker, 100)),
                new Card(new CollectMoneyCommand(banker, 45)),
                new Card(new CollectMoneyCommand(banker, 200)),
                new Card(new PayMoneyCommand(banker, 100)),
                new Card(new PayMoneyCommand(banker, 50)),
                new Card(new GetOutOfJailFreeCommand(jailRoster)),
                new Card(new CollectMoneyCommand(banker, 25)),
                new Card(new PayMoneyCommand(banker, 150)),
                new Card(new AdvanceTokenCommand(0, board)),
                new Card(new CollectMoneyCommand(banker, 10)),
                new Card(new CollectMoneyFromAllPlayersCommand(banker, 50)),
                new Card(new CollectMoneyCommand(banker, 20)),
                new Card(new NullCommand()),
                new Card(new CollectMoneyCommand(banker, 100)),
                new Card(new GoDirectlyToJailCommand(jailRoster, board))
            };

            return cards.ToList();
        }
    }
}
