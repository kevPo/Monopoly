using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Locations;

namespace Monopoly.Turns
{
    public abstract class Turn
    {
        protected Int32 playerId;
        protected IDice dice;
        protected IJailRoster jailRoster;
        protected IPlayerService playerService;
        protected IEnumerable<Location> locations;
        protected Int32 currentLocationIndex;

        public Turn(Int32 playerId, IDice dice, IJailRoster jailRoster, 
                    IPlayerService playerService, IEnumerable<Location> locations)
        {
            this.playerId = playerId;
            this.dice = dice;
            this.jailRoster = jailRoster;
            this.playerService = playerService;
            this.locations = locations;
            this.currentLocationIndex = playerService.GetLocationIndexFor(playerId);
        }

        public abstract void Take();

        protected void SendPlayerToDestination()
        {
            var roll = dice.GetCurrentRoll();

            for (var locationsPassed = 1; locationsPassed <= roll; locationsPassed++)
                SetPlayerOnNextLocation(roll, locationsPassed, GetCurrentLocation());
        }

        private Location GetCurrentLocation()
        {
            currentLocationIndex = (currentLocationIndex + 1) % locations.Count();
            var location = locations.First(l => l.Index == currentLocationIndex);

            return location;
        }

        private void SetPlayerOnNextLocation(Int32 roll, Int32 locationsPassed, Location location)
        {
            if (locationsPassed == roll)
                SetPlayerOnDestination(location);
            else
                location.PassedOverBy(playerId);
        }

        private void SetPlayerOnDestination(Location location)
        {
            playerService.SetLocationIndexFor(playerId, location.Index);
            location.LandedOnBy(playerId);
        }
    }
}
