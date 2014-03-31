using System;
using Monopoly.Banker;
using Monopoly.Dice;
using Monopoly.JailRoster;
using Monopoly.Locations.Factories;
using Monopoly.Locations.Managers;

namespace Monopoly.Turns
{
    public class TraditionalTurnFactory : ITurnFactory
    {
        private IBanker banker;
        private TraditionalDice dice;
        private TraditionalJailRoster jailRoster;
        private LocationManager locationManager;

        public TraditionalTurnFactory(TraditionalBanker banker)
        {
            this.dice = new TraditionalDice();
            this.jailRoster = new TraditionalJailRoster(banker);
            this.locationManager = new LocationManager();
            var locationFactory = new TraditionalLocationFactory(banker, dice, jailRoster, locationManager);
            this.locationManager.SetLocations(locationFactory.GetLocations());
        }

        public Turn GetTurnFor(Int32 playerId)
        {
            if (jailRoster.IsInJail(playerId))
                return new InmateTurn(playerId, dice, jailRoster, locationManager);
            else
                return new NormalTurn(playerId, dice, jailRoster, locationManager);
        }
    }
}
