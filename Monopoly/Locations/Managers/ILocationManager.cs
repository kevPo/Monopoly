using System;
using System.Collections.Generic;
using Monopoly.Locations.Defaults;
namespace Monopoly.Locations.Managers
{
    public interface ILocationManager
    {
        void SetLocations(IEnumerable<Location> locations);
        void SetLocationIndexFor(Int32 playerId, Int32 locationIndex);
        Int32 GetLocationIndexFor(Int32 playerId);
        IEnumerable<Location> GetLocations();
    }
}
