using System;
using System.Collections.Generic;
using Monopoly.Locations;

namespace Monopoly.Turns
{
    public class TurnFactory : ITurnFactory
    {
        private IDice dice;
        private IJailRoster jailRoster;
        private IPlayerService playerService;
        private IEnumerable<Location> locations;

        public TurnFactory(IDice dice, IJailRoster jailRoster, IPlayerService playerService, 
                           IEnumerable<Location> locations)
        {
            this.dice = dice;
            this.jailRoster = jailRoster;
            this.playerService = playerService;
            this.locations = locations;
        }

        public Turn GetTurnFor(Int32 playerId)
        {
            if (jailRoster.IsInJail(playerId))
                return new InmateTurn(playerId, dice, jailRoster, playerService, locations);
            else
                return new NormalTurn(playerId, dice, jailRoster, playerService, locations);
        }
    }
}
