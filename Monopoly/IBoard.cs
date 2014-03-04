using System;
namespace Monopoly
{
    public interface IBoard
    {
        Location GetStartingLocation();
        Location GetLocationFor(String name);
        void MovePlayer(IPlayer player, Int32 rolled);
    }
}
