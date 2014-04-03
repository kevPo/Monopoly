using System;
using System.Collections.Generic;
using Monopoly.Locations.Defaults;
using Monopoly.Locations.Propertys;

namespace Monopoly.Board
{
    public interface IBoard
    {
        void SetLocations(IEnumerable<Location> locations, IEnumerable<Railroad> railroads, 
            IEnumerable<Utility> utilities);
        void SetLocationIndexFor(Int32 playerId, Int32 locationIndex);
        Int32 GetLocationIndexFor(Int32 playerId);
        IEnumerable<Location> GetLocations();
        Int32 GetNumberOfLocations();
        Railroad GetNearestRailroadFor(Int32 playerId);
        Utility GetNearestUtilityFor(Int32 playerId);
    }
}
