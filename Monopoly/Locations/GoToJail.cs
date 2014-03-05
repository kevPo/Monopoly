using System;

namespace Monopoly.Locations
{
    public class GoToJail : Location
    {
        private Jail jail;

        public GoToJail(Jail jail) : base("Go To Jail")
        {
            this.jail = jail;
        }

        public override void LandedOnBy(IPlayer player)
        {
            player.GoDirectlyTo(jail);
        }
    }
}
