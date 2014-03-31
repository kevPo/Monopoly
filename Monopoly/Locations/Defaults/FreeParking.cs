using System;
using Monopoly.Banker;
namespace Monopoly.Locations.Defaults
{
    public class FreeParking : Location
    {
        public FreeParking(Int32 index, String name, IBanker banker)
            : base(index, name, banker)
        { }

        public override void LandedOnBy(Int32 playerId)
        { }
    }
}
