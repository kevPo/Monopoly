using System;

namespace Monopoly
{
    public class GameMediator
    {
        private IBoard board;
        private ILocationAssessor locationAssessor;

        public GameMediator(IBoard board, ILocationAssessor locationAssessor)
        {
            this.board = board;
            this.locationAssessor = locationAssessor;
        }

        public MovementResult MovePlayer(Player player, Int32 rolled)
        {
            var movementResult = board.UpdateLocation(player.Location, rolled);
            var balance = player.Balance + movementResult.Balance;
            return locationAssessor.GetAssesmentFor(movementResult.Location, balance);
        }

        public String GetStartingPosition()
        {
            return board.GetStartingLocation();
        }
    }
}
