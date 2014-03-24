using System;

namespace Monopoly.Locations
{
    public class GoToJail : Location
    {
        private Int32 jailIndex;
        private IJailRoster jailRoster;

        public GoToJail(Int32 index, String name, Int32 jailIndex, IJailRoster jailRoster) : base(index, name)
        {
            this.jailIndex = jailIndex;
            this.jailRoster = jailRoster;
        }

        public override void LandedOnBy(IPlayer player)
        {
            player.LandedOn(jailIndex);
            jailRoster.Add(player);
        }
    }
}
