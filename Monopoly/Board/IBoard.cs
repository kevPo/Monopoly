using System;
using System.Collections.Generic;
using Monopoly.Locations.Defaults;
using Monopoly.Locations.Propertys;

namespace Monopoly.Board
{
    public interface IBoard
    {
        void SetLocations(IEnumerable<Location> locations, IEnumerable<Railroad> railroads, IEnumerable<Utility> utilities);
        IEnumerable<Location> Locations { get; }
        Int32 GetLocationIndexFor(Int32 playerId);
        void MovePlayer(Int32 playerId, Int32 locationsToMove);
        void MovePlayerTo(Int32 playerId, Int32 locationIndex);
        void SendPlayerDirectlyTo(Int32 playerId, Int32 locationIndex);
        void SendPlayerDirectlyToJail(Int32 playerId);
        void SendPlayerToNearestUtility(Int32 playerId);
        void SendPlayerToNearestRailroad(Int32 playerId);
    }
}
