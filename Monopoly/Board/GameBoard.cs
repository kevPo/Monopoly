using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Locations.Defaults;
using Monopoly.Locations.Propertys;

namespace Monopoly.Board
{
    public class GameBoard : IBoard
    {
        private IDictionary<Int32, Int32> playerLocations;
        private IEnumerable<Location> locations;
        private IEnumerable<Railroad> railroads;
        private IEnumerable<Utility> utilities;

        public void SetLocations(IEnumerable<Location> locations, IEnumerable<Railroad> railroads,
            IEnumerable<Utility> utilities)
        {
            this.locations = AggregateAllLocations(locations, railroads, utilities);
            this.railroads = railroads;
            this.utilities = utilities;
            playerLocations = new Dictionary<Int32, Int32>();
        }

        private IEnumerable<Location> AggregateAllLocations(IEnumerable<Location> locations, 
            IEnumerable<Railroad> railroads, IEnumerable<Utility> utilities)
        {
            var allLocations = new List<Location>();
            allLocations.AddRange(locations);
            allLocations.AddRange(railroads);
            allLocations.AddRange(utilities);
            return allLocations;
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

        public Int32 GetNumberOfLocations()
        {
            return locations.Count();
        }

        public Railroad GetNearestRailroadFor(Int32 playerId)
        {
            return GetNearestPropertyInGroupFor(GetLocationIndexFor(playerId), railroads) as Railroad;
        }

        public Utility GetNearestUtilityFor(Int32 playerId)
        {
            return GetNearestPropertyInGroupFor(GetLocationIndexFor(playerId), utilities) as Utility;
        }

        private Property GetNearestPropertyInGroupFor(Int32 locationIndex, IEnumerable<Property> properties)
        {
            var firstPropertyIndex = properties.Select(r => r.Index).Min();
            var lastPropertyIndex = properties.Select(r => r.Index).Max();

            if (locationIndex >= lastPropertyIndex)
                return properties.FirstOrDefault(r => r.Index == firstPropertyIndex);
            else
                return properties.FirstOrDefault(r => r.Index > locationIndex);
        }
    }
}
