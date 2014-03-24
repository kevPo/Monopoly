using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Locations;

namespace Monopoly.Board
{
    public class GameBoard : IBoard
    {
        public IDice Dice { get; private set; }
        private IJailRoster jailRoster;
        private List<Location> locations;
        
        public GameBoard(IDice dice, IJailRoster jailRoster)
        {
            Dice = dice;
            this.jailRoster = jailRoster;
            locations = new List<Location>();
        }

        public Location GetStartingLocation()
        {
            return locations.FirstOrDefault(l => l.Index == 0);
        }

        public void AddLocation(Location location)
        {
            if (locations.Count > 40)
                throw new InvalidOperationException("Location can not be added.  Board is full.");

            locations.Add(location);
        }

        public virtual void TakeTurnFor(IPlayer player)
        {
            var turn = new Turn(locations, jailRoster, player, Dice);
            turn.Take();
        }
    }
}
