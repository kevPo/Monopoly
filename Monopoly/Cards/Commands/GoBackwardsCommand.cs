using System;
using Monopoly.Board;

namespace Monopoly.Cards.Commands
{
    public class GoBackwardsCommand : ICommand
    {
        private Int32 locationsBackward;
        private IBoard board;

        public GoBackwardsCommand(Int32 locationsBackward, IBoard board)
        {
            this.locationsBackward = locationsBackward * -1;
            this.board = board;
        }

        public void PerformOn(Int32 playerId)
        {
            board.MovePlayer(playerId, locationsBackward);
        }
    }
}
