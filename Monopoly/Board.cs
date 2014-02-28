using System;
using System.Collections.Generic;

namespace Monopoly
{
    public class Board
    {
        private LinkedList<String> locations;
        
        public Board()
        {
            locations = new LinkedList<String>();
            locations.AddFirst("Go");
            locations.AddLast("Mediterranean Avenue");
            locations.AddLast("Community Chest");
            locations.AddLast("Baltic Avenue");
            locations.AddLast("Income Tax");
            locations.AddLast("Reading Railroad");
            locations.AddLast("Oriental Avenue");
            locations.AddLast("Chance");
            locations.AddLast("Vermont Avenue");
            locations.AddLast("Connecticut Avenue");
            locations.AddLast("Jail/ Just Visiting");
            locations.AddLast("St. Charles Place");
            locations.AddLast("Electric Company");
            locations.AddLast("States Avenue");
            locations.AddLast("Virginia Avenue");
            locations.AddLast("Pennsylvania Railroad");
            locations.AddLast("St. James Place");
            locations.AddLast("Community Chest");
            locations.AddLast("Tennessee Avenue");
            locations.AddLast("New York Avenue");
            locations.AddLast("Free Parking");
            locations.AddLast("Kentucky Avenue");
            locations.AddLast("Chance");
            locations.AddLast("Indiana Avenue");
            locations.AddLast("Illinois Avenue");
            locations.AddLast("B. & O. Railroad");
            locations.AddLast("Atlantic Avenue");
            locations.AddLast("Ventnor Avenue");
            locations.AddLast("Water Works");
            locations.AddLast("Marvin Gardens");
            locations.AddLast("Go To Jail");
            locations.AddLast("Pacific Avenue");
            locations.AddLast("North Carolina Avenue");
            locations.AddLast("Community Chest");
            locations.AddLast("Pennsylvania Avenue");
            locations.AddLast("Short Line");
            locations.AddLast("Chance");
            locations.AddLast("Park Place");
            locations.AddLast("Luxury Tax");
            locations.AddLast("Boardwalk");
        }

        public String GetStartingLocation()
        {
            return locations.First.Value;
        }

        public MovementResult UpdateLocation(String currentPosition, Int32 movement)
        {
            var current = locations.Find(currentPosition);
            var currencyGained = 0;

            for (var i = 0; i < movement; i++)
            {
                if (current.Next == null)
                {
                    current = locations.First;
                    currencyGained += 200;
                }
                else
                {
                    current = current.Next;                    
                }
            }

            if (current.Value == "Go To Jail")
                current = locations.Find("Jail/ Just Visiting");

            return new MovementResult(current.Value, currencyGained);             
        }
    }
}
