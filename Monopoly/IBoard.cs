using System;
using System.Collections.Generic;
using Monopoly.Locations;
namespace Monopoly
{
    public interface IBoard
    {
        void Initialize(IEnumerable<IPlayer> players);
        Location GetStartingLocation();
        Location GetLocationFor(String name);
        void MovePlayer(IPlayer player, Int32 rolled);
    }
}
