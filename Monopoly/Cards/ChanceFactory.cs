using System.Collections.Generic;
using System.Linq;
using Monopoly.Banker;
using Monopoly.Board;
using Monopoly.Cards.Commands;
using Monopoly.Dice;
using Monopoly.JailRoster;

namespace Monopoly.Cards
{
    public class ChanceFactory : CardsFactory
    {
        private IBanker banker;
        private IJailRoster jailRoster;
        private GameBoard board;
        private IDice dice;

        public ChanceFactory(IBanker banker, IJailRoster jailRoster, 
            GameBoard board, IDice dice)
        {
            this.banker = banker;
            this.jailRoster = jailRoster;
            this.board = board;
            this.dice = dice;
        }

        protected override List<ICard> CreateCards()
        {
            var cards = new ICard[]
            {
                new Card(new CollectMoneyCommand(banker, 50)),
                new Card(new GoDirectlyToJailCommand(jailRoster, board)),
                new Card(new PayEachPlayerCommand(banker, 50)),
                new Card(new AdvanceToNearestRailroadCommand(board)),
                new Card(new AdvanceTokenCommand(24, board)),
                new Card(new AdvanceTokenCommand(0, board)),
                new Card(new GoBackwardsCommand(3, board)),
                new Card(new PayMoneyCommand(banker, 15)),
                new Card(new AdvanceToNearestRailroadCommand(board)),
                new Card(new AdvanceTokenCommand(39, board)),
                new Card(new GetOutOfJailFreeCommand(jailRoster)),
                new Card(new AdvanceToNearestUtilityCommand(board)),
                new Card(new AdvanceAndCollectSalaryIfGoIsPassedCommand(11, board)),
                new Card(new AdvanceAndCollectSalaryIfGoIsPassedCommand(5, board)),
                new Card(new CollectMoneyCommand(banker, 150)),
                new Card(new NullCommand())
            };

            return cards.ToList();
        }
    }
}
