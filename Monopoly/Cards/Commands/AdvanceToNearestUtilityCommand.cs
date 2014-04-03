using System;
using Monopoly.Banker;
using Monopoly.Board;
using Monopoly.Dice;
using Monopoly.Locations.Propertys;

namespace Monopoly.Cards.Commands
{
    public class AdvanceToNearestUtilityCommand : ICommand
    {
        private IBanker banker;
        private GameBoard board;
        private IDice dice;

        public AdvanceToNearestUtilityCommand(IBanker banker, GameBoard board, IDice dice)
        {
            this.banker = banker;
            this.board = board;
            this.dice = dice;
        }

        public void PerformOn(Int32 playerId)
        {
            var utility = board.GetNearestUtilityFor(playerId);

            if (!utility.IsOwned)
                utility.LandedOnBy(playerId);
            else
                RollDiceAndPayOwnerTenTimesTheRoll(playerId, utility);

            board.SetLocationIndexFor(playerId, utility.Index);               
        }

        private void RollDiceAndPayOwnerTenTimesTheRoll(Int32 playerId, Property utility)
        {
            dice.Roll();
            var rent = dice.GetCurrentRoll() * 10;
            banker.TransferMoney(playerId, utility.OwnerId, rent);
        }
    }
}
