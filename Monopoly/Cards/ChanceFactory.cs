using Monopoly.Banker;
using Monopoly.Board;
using Monopoly.Cards.Commands;
using Monopoly.Dice;
using Monopoly.JailRoster;

namespace Monopoly.Cards
{
    public class ChanceFactory : CardsFactory
    {
        public ChanceFactory(IBanker banker, IJailRoster jailRoster, 
            GameBoard board, IDice dice)
        {
            CreateDeck(banker, jailRoster, board, dice);
        }

        public void CreateDeck(IBanker banker, IJailRoster jailRoster, 
            GameBoard board, IDice dice)
        {
            AddCard(new Card(new CollectMoneyCommand(banker, 50)));
            AddCard(new Card(new GoDirectlyToJailCommand(jailRoster, board)));
            AddCard(new Card(new PayEachPlayerCommand(banker, 50)));
            AddCard(new Card(new AdvanceToNearestRailroadCommand(banker, board)));
            AddCard(new Card(new AdvanceTokenCommand(24, board)));
            AddCard(new Card(new AdvanceTokenCommand(0, board)));
            AddCard(new Card(new GoBackwardsCommand(3, board)));
            AddCard(new Card(new PayMoneyCommand(banker, 15)));
            AddCard(new Card(new AdvanceToNearestRailroadCommand(banker, board)));
            AddCard(new Card(new AdvanceTokenCommand(39, board)));
            AddCard(new Card(new GetOutOfJailFreeCommand(jailRoster)));
            AddCard(new Card(new AdvanceToNearestUtilityCommand(banker, board, dice)));
            AddCard(new Card(new AdvanceAndCollectSalaryIfGoIsPassedCommand(11, board, banker)));
            AddCard(new Card(new AdvanceAndCollectSalaryIfGoIsPassedCommand(5, board, banker)));
            AddCard(new Card(new CollectMoneyCommand(banker, 150)));
            AddCard(new Card(new PropertyRepairCommand(banker, 25, 100)));
        }
    }
}
