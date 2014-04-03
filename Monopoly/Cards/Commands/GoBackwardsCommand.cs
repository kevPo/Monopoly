using System;
using Monopoly.Board;

namespace Monopoly.Cards.Commands
{
    public class GoBackwardsCommand : ICommand
    {
        private Int32 locationsBackward;
        private GameBoard board;

        public GoBackwardsCommand(Int32 locationsBackward, GameBoard board)
        {
            this.locationsBackward = locationsBackward;
            this.board = board;
        }

        public void PerformOn(Int32 playerId)
        {
            var numberOfLocations = board.GetNumberOfLocations();
            var currentLocation = board.GetLocationIndexFor(playerId);
            var nextLocation = (currentLocation + (numberOfLocations - locationsBackward)) % numberOfLocations;

            var advanceTokenCommand = new AdvanceTokenCommand(nextLocation, board);
            advanceTokenCommand.PerformOn(playerId);
        }
    }
}
