using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Locations;
using Monopoly.Locations.Taxable;

namespace Monopoly
{
    public class Board : IBoard
    {
        private IEnumerable<IPlayer> players;
        private List<Location> locations;
        
        public Board()
        {
            var jail = new Jail();

            locations = new List<Location>
            {
                new Property("Go", 0),
                new Property("Mediterranean Avenue", 60),
                new CardDraw("Community Chest"),
                new Property("Baltic Avenue", 60),
                new IncomeTax(),
                new Property("Reading Railroad", 200),
                new Property("Oriental Avenue", 100),
                new CardDraw("Chance"),
                new Property("Vermont Avenue", 100),
                new Property("Connecticut Avenue", 120),
                jail,
                new Property("St. Charles Place", 140),
                new Property("Electric Company", 150),
                new Property("States Avenue", 140),
                new Property("Virginia Avenue", 160),
                new Property("Pennsylvania Railroad", 200),
                new Property("St. James Place", 180),
                new CardDraw("Community Chest"),
                new Property("Tennessee Avenue", 180),
                new Property("New York Avenue", 200),
                new Property("Free Parking", 0),
                new Property("Kentucky Avenue", 220),
                new CardDraw("Chance"),
                new Property("Indiana Avenue", 220),
                new Property("Illinois Avenue", 240),
                new Property("B. & O. Railroad", 200),
                new Property("Atlantic Avenue", 260),
                new Property("Ventnor Avenue", 260),
                new Property("Water Works", 150),
                new Property("Marvin Gardens", 280),
                new GoToJail(jail),
                new Property("Pacific Avenue", 300),
                new Property("North Carolina Avenue", 300),
                new CardDraw("Community Chest"),
                new Property("Pennsylvania Avenue", 320),
                new Property("Short Line", 200),
                new CardDraw("Chance"),
                new Property("Park Place", 350),
                new LuxuryTax(),
                new Property("Boardwalk", 400)
            };
        }

        public void Initialize(IEnumerable<IPlayer> players)
        {
            this.players = players;

            foreach (var player in players)
                player.GoDirectlyTo(GetStartingLocation());
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
