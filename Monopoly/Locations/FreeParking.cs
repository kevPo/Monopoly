using System;
namespace Monopoly.Locations
{
    public class FreeParking : Location
    {
        public FreeParking(Int32 index, String name, IPlayerRepository playerRepository)
            : base(index, name, playerRepository)
        { }

        public override void LandedOnBy(Int32 playerId)
        { }
    }
}
