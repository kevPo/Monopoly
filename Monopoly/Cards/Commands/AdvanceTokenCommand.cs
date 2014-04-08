using System;
using Monopoly.Board;

namespace Monopoly.Cards.Commands
{
    public class AdvanceTokenCommand : ICommand
    {
        protected Int32 locationIndex;
        protected IBoard board;
        
        public AdvanceTokenCommand(Int32 locationIndex, IBoard board)
        {
            this.locationIndex = locationIndex;
            this.board = board;
        }

        public void PerformOn(Int32 playerId)
        {
            board.SendPlayerDirectlyTo(playerId, locationIndex);
        }
    }
}
