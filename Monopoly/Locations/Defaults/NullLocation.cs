using System;

namespace Monopoly.Locations.Defaults
{
    public class NullLocation : Location
    {
        public NullLocation(Int32 index, String name)
            : base(index, name)
        { }

        public override void LandedOnBy(Int32 playerId)
        { }
    }
}
