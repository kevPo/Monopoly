using System;
namespace Monopoly.Locations
{
    public class FreeParking : Location
    {
        public FreeParking(Int32 index, String name) : base(index, name)
        { }

        public override void LandedOnBy(IPlayer player)
        { }
    }
}
