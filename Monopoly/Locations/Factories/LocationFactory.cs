using System.Collections.Generic;
using Monopoly.Locations.Defaults;

namespace Monopoly.Locations.Factories
{
    public abstract class LocationFactory
    {
        protected IEnumerable<Location> locations;

        public IEnumerable<Location> GetLocations()
        {
            CreateLocations();
            return locations;
        }

        protected abstract void CreateLocations();
    }
}
