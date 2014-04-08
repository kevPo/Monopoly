using System;
using Monopoly.Board;

namespace Monopoly.Cards.Commands
{
    public class AdvanceToNearestRailroadCommand : ICommand
    {
        private IBoard board;

        public AdvanceToNearestRailroadCommand(IBoard board)
        {
            this.board = board;
        }

        public void PerformOn(Int32 playerId)
        {
            board.SendPlayerToNearestRailroad(playerId);          
        }
    }
}
