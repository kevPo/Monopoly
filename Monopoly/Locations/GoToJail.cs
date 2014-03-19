using System;

namespace Monopoly.Locations
{
    public class GoToJail : Location
    {
        private Jail jail;
        private IJailRoster jailRoster;

        public GoToJail(Int32 index, String name, Jail jail, IJailRoster jailRoster) : base(index, name)
        {
            this.jail = jail;
            this.jailRoster = jailRoster;
        }

        public override void LandedOnBy(IPlayer player)
        {
            player.LandedOn(jail);
            jailRoster.Add(player);
        }
    }
}
