using System;

namespace Monopoly.Locations
{
    public class GoToJail : Location
    {
        private Int32 jailIndex;
        private IJailRoster jailRoster;

        public GoToJail(Int32 index, String name, Int32 jailIndex, IPlayerRepository playerRepository, 
                        IJailRoster jailRoster) : base(index, name, playerRepository)
        {
            this.jailIndex = jailIndex;
            this.jailRoster = jailRoster;
        }

        public override void LandedOnBy(Int32 playerId)
        {
            playerRepository.SetLocationIndexFor(playerId, jailIndex);
            jailRoster.Add(playerId);
        }
    }
}
