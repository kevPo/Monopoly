using System;

namespace Monopoly.Locations
{
    public class GoToJail : Location
    {
        private Int32 jailIndex;
        private IJailRoster jailRoster;

        public GoToJail(Int32 index, String name, Int32 jailIndex, IPlayerService playerService, 
                        IJailRoster jailRoster) : base(index, name, playerService)
        {
            this.jailIndex = jailIndex;
            this.jailRoster = jailRoster;
        }

        public override void LandedOnBy(Int32 playerId)
        {
            playerService.SetLocationIndexFor(playerId, jailIndex);
            jailRoster.Add(playerId);
        }
    }
}
