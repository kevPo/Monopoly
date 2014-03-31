using System;
using Monopoly.Banker;
using Monopoly.JailRoster;
using Monopoly.Locations.Managers;

namespace Monopoly.Locations.Defaults
{
    public class GoToJail : Location
    {
        private Int32 jailIndex;
        private IJailRoster jailRoster;
        private ILocationManager locationManager;

        public GoToJail(Int32 index, String name, Int32 jailIndex, IBanker banker, 
                        IJailRoster jailRoster, ILocationManager locationManager) : base(index, name, banker)
        {
            this.jailIndex = jailIndex;
            this.jailRoster = jailRoster;
            this.locationManager = locationManager;
        }

        public override void LandedOnBy(Int32 playerId)
        {
            locationManager.SetLocationIndexFor(playerId, jailIndex);
            jailRoster.Add(playerId);
        }
    }
}
