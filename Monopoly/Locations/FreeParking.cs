using System;
namespace Monopoly.Locations
{
    public class FreeParking : Location
    {
        public FreeParking(Int32 index, String name, IPlayerService playerService)
            : base(index, name, playerService)
        { }

        public override void LandedOnBy(Int32 playerId)
        { }
    }
}
