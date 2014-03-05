using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Locations;
using Monopoly.Locations.Taxable;

namespace Monopoly
{
    public class Board : IBoard
    {
        private List<Location> locations;
        
        public Board()
        {
            var jail = new Jail();

            locations = new List<Location>
            {
                new Starter(),
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

        public Starter GetStartingLocation()
        {
            return locations.FirstOrDefault() as Starter;
        }

        public void MovePlayer(IPlayer player, Int32 rolled)
        {
            if (rolled == 0) return;
            var index = locations.IndexOf(player.Location);
            
            for (var moved = 1; moved <= rolled; moved++)
            {
                index += 1;
                
                if (index > 39)
                    index = 0;

                if (moved == rolled)
                {
                    player.LandedOn(locations[index]);
                    locations[index].LandedOnBy(player);
                }
                else
                {
                    locations[index].PassedOverBy(player);
                }
            }
        }
    }
}
