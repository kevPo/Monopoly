using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    public class LocationAssistant
    {
        private IEnumerable<Location> locations;
        
        public LocationAssistant()
        {
            locations = new HashSet<Location> {
                new Location(0, "Go"),
                new Location(1, "Mediterranean Avenue"),
                new Location(2, "Community Chest"),
                new Location(3, "Baltic Avenue"),
                new Location(4, "Income Tax"),
                new Location(5, "Reading Railroad"),
                new Location(6, "Oriental Avenue"),
                new Location(7, "Chance"),
                new Location(8, "Vermont Avenue"),
                new Location(9, "Connecticut Avenue"),
                new Location(10, "Jail/ Just Visiting"),
                new Location(11, "St. Charles Place"),
                new Location(12, "Electric Company"),
                new Location(13, "States Avenue"),
                new Location(14, "Virginia Avenue"),
                new Location(15, "Pennsylvania Railroad"),
                new Location(16, "St. James Place"),
                new Location(17, "Community Chest"),
                new Location(18, "Tennessee Avenue"),
                new Location(19, "New York Avenue"),
                new Location(20, "Free Parking"),
                new Location(21, "Kentucky Avenue"),
                new Location(22, "Chance"),
                new Location(23, "Indiana Avenue"),
                new Location(24, "Illinois Avenue"),
                new Location(25, "B. & O. Railroad"),
                new Location(26, "Atlantic Avenue"),
                new Location(27, "Ventnor Avenue"),
                new Location(28, "Water Works"),
                new Location(29, "Marvin Gardens"),
                new Location(30, "Go To Jail"),
                new Location(31, "Pacific Avenue"),
                new Location(32, "North Carolina Avenue"),
                new Location(33, "Community Chest"),
                new Location(34, "Pennsylvania Avenue"),
                new Location(35, "Short Line"),
                new Location(36, "Chance"),
                new Location(37, "Park Place"),
                new Location(38, "Luxury Tax"),
                new Location(39, "Boardwalk")
            }; 
        }

        public Location GetStartingLocation()
        {
            return locations.First();
        }

        public Location GetLocationAt(Int32 locationId)
        {
            return locations.FirstOrDefault(l => l.Id == locationId);
        }
    }
}
