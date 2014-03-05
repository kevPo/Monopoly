using System;
using Monopoly.Locations;
namespace Monopoly
{
    public interface IBoard
    {
        Starter GetStartingLocation();
        void MovePlayer(IPlayer player, Int32 rolled);
    }
}
