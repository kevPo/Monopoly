using System;
using Monopoly.Board;

namespace Monopoly.Cards.Commands
{
    public class AdvanceToNearestUtilityCommand : ICommand
    {
        private IBoard board;

        public AdvanceToNearestUtilityCommand(IBoard board)
        {
            this.board = board;
        }

        public void PerformOn(Int32 playerId)
        {
            board.SendPlayerToNearestUtility(playerId);           
        }
    }
}
