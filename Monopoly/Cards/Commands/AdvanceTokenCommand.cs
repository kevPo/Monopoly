using System;
using System.Linq;
using Monopoly.Board;

namespace Monopoly.Cards.Commands
{
    public class AdvanceTokenCommand : ICommand
    {
        protected Int32 locationIndex;
        protected GameBoard board;
        
        public AdvanceTokenCommand(Int32 locationIndex, GameBoard board)
        {
            this.locationIndex = locationIndex;
            this.board = board;
        }

        public virtual void PerformOn(Int32 playerId)
        {
            board.SetLocationIndexFor(playerId, locationIndex);
            var destination = board.GetLocations().First(l => l.Index == locationIndex);
            destination.LandedOnBy(playerId);
        }
    }
}
