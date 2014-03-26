using System;
namespace Monopoly.Locations
{
    public class Jail : Location
    {
        public Jail(Int32 index, String name, IPlayerRepository playerRepository) : base(index, name, playerRepository)
        { }

        public override void LandedOnBy(Int32 playerId)
        { }
    }
}
