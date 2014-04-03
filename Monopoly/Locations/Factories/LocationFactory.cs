using System.Collections.Generic;
using Monopoly.Locations.Defaults;
using Monopoly.Locations.Propertys;

namespace Monopoly.Locations.Factories
{
    public abstract class LocationFactory
    {
        public abstract IEnumerable<Location> GetLocations();
        public abstract IEnumerable<Railroad> GetRailroads();
        public abstract IEnumerable<Utility> GetUtilities();
    }
}
