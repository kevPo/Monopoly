using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Assessors;

namespace Monopoly
{
    public class Board : IBoard
    {
        private List<Location> locations;
        
        public Board()
        {
            locations = new List<Location>
            {
                new Location("Go", new DefaultAssessor()),
                new Location("Mediterranean Avenue", new DefaultAssessor()),
                new Location("Community Chest", new DefaultAssessor()),
                new Location("Baltic Avenue", new DefaultAssessor()),
                new Location("Income Tax", new IncomeTaxAssessor()),
                new Location("Reading Railroad", new DefaultAssessor()),
                new Location("Oriental Avenue", new DefaultAssessor()),
                new Location("Chance", new DefaultAssessor()),
                new Location("Vermont Avenue", new DefaultAssessor()),
                new Location("Connecticut Avenue", new DefaultAssessor()),
                new Location("Jail/ Just Visiting", new DefaultAssessor()),
                new Location("St. Charles Place", new DefaultAssessor()),
                new Location("Electric Company", new DefaultAssessor()),
                new Location("States Avenue", new DefaultAssessor()),
                new Location("Virginia Avenue", new DefaultAssessor()),
                new Location("Pennsylvania Railroad", new DefaultAssessor()),
                new Location("St. James Place", new DefaultAssessor()),
                new Location("Community Chest", new DefaultAssessor()),
                new Location("Tennessee Avenue", new DefaultAssessor()),
                new Location("New York Avenue", new DefaultAssessor()),
                new Location("Free Parking", new DefaultAssessor()),
                new Location("Kentucky Avenue", new DefaultAssessor()),
                new Location("Chance", new DefaultAssessor()),
                new Location("Indiana Avenue", new DefaultAssessor()),
                new Location("Illinois Avenue", new DefaultAssessor()),
                new Location("B. & O. Railroad", new DefaultAssessor()),
                new Location("Atlantic Avenue", new DefaultAssessor()),
                new Location("Ventnor Avenue", new DefaultAssessor()),
                new Location("Water Works", new DefaultAssessor()),
                new Location("Marvin Gardens", new DefaultAssessor()),
                new Location("Go To Jail", new GoToJailAssessor()),
                new Location("Pacific Avenue", new DefaultAssessor()),
                new Location("North Carolina Avenue", new DefaultAssessor()),
                new Location("Community Chest", new DefaultAssessor()),
                new Location("Pennsylvania Avenue", new DefaultAssessor()),
                new Location("Short Line", new DefaultAssessor()),
                new Location("Chance", new DefaultAssessor()),
                new Location("Park Place", new DefaultAssessor()),
                new Location("Luxury Tax", new LuxuryTaxAssessor()),
                new Location("Boardwalk", new DefaultAssessor())
            };
        }

        public Location GetStartingLocation()
        {
            return locations.FirstOrDefault();
        }

        public void MovePlayer(IPlayer player, Int32 rolled)
        {
            var result = GetMovementResult(player.Location, rolled);

            if (result.Balance > 0)
                player.ReceiveMoney(result.Balance);

            player.LandedOn(result.Location);
        }

        private MovementResult GetMovementResult(Location currentLocation, Int32 movement)
        {
            var index = locations.IndexOf(currentLocation);
            var currencyGained = 0;

            for (var i = 1; i <= movement; i++)
            {
                index += 1;
                if (index > 39)
                {
                    index = 0;
                    currencyGained += 200;
                }
            }

            return new MovementResult(locations[index], currencyGained);             
        }

        public Location GetLocationFor(String name)
        {
            return locations.FirstOrDefault(l => l.Name == name);
        }
    }
}
