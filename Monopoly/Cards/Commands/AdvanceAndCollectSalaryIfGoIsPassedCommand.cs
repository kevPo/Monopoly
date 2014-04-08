using System;
using Monopoly.Board;

namespace Monopoly.Cards.Commands
{
    public class AdvanceAndCollectSalaryIfGoIsPassedCommand : ICommand
    {
        private Int32 destinationIndex;
        private IBoard board;
        
        public AdvanceAndCollectSalaryIfGoIsPassedCommand(Int32 destinationIndex, IBoard board) 
        {
            this.destinationIndex = destinationIndex;
            this.board = board;
        }

        public void PerformOn(Int32 playerId)
        {
            board.MovePlayerTo(playerId, destinationIndex);
        }
    }
}
