using System;
namespace Monopoly
{
    public interface IBoard
    {
        Location GetStartingLocation();
        MovementResult GetMovementResult(Location currentPosition, Int32 movement);
        Location GetLocationFor(String name);
        void MovePlayer(IPlayer player, Int32 rolled);
    }
}
