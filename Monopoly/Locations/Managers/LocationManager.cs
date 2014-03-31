using System;
using System.Collections.Generic;
using Monopoly.Locations.Defaults;

namespace Monopoly.Locations.Managers
{
    public class LocationManager : ILocationManager
    {
        private IDictionary<Int32, Int32> playerLocations;
        private IEnumerable<Location> locations;

        public void SetLocations(IEnumerable<Location> locations)
        {
            this.locations = locations;
            playerLocations = new Dictionary<Int32, Int32>();
        }

        public void SetLocationIndexFor(Int32 playerId, Int32 locationIndex)
        {
            playerLocations.Remove(playerId);
            playerLocations.Add(playerId, locationIndex);
        }

        public Int32 GetLocationIndexFor(Int32 playerId)
        {
            try
            {
                return playerLocations[playerId];
            }
            catch
            {
                SetLocationIndexFor(playerId, 0);
                return 0;
            }
        }

        public IEnumerable<Location> GetLocations()
        {
            return locations;
        }
    }
}
