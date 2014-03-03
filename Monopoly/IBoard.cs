using System;
namespace Monopoly
{
    public interface IBoard
    {
        String GetStartingLocation();
        MovementResult UpdateLocation(String currentPosition, Int32 movement);
    }
}
