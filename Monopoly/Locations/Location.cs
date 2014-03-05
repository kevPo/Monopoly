using System;

namespace Monopoly.Locations
{
    public abstract class Location
    {
        public String Name { get; private set; }

        public Location(String name)
        {
            this.Name = name;
        }

        public abstract void LandedOnBy(IPlayer player);
    }
}
