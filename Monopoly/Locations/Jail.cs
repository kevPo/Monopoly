using System;
namespace Monopoly.Locations
{
    public class Jail : Location
    {
        public Jail(Int32 index, String name, IPlayerService playerService) : base(index, name, playerService)
        { }

        public override void LandedOnBy(Int32 playerId)
        { }
    }
}
