using System;

namespace Monopoly.Locations
{
    public class GoToJail : Location
    {
        private Jail jail;

        public GoToJail(Int32 index, String name, Jail jail) : base(index, name)
        {
            this.jail = jail;
        }

        public override void LandedOnBy(IPlayer player)
        {
            player.LandedOn(jail);
        }
    }
}
