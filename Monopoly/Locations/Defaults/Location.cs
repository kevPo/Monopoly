using System;

namespace Monopoly.Locations.Defaults
{
    public abstract class Location
    {
        public Int32 Index { get; private set; }
        public String Name { get; private set; }

        public Location(Int32 index, String name)
        {
            Index = index;
            Name = name;
        }

        public abstract void LandedOnBy(Int32 playerId);
    }
}
