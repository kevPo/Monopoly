using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Locations;
using Monopoly.PropertyGroups;

namespace Monopoly.Board
{
    public class GameBoard : IBoard
    {
        private List<Location> locations;
        private List<PropertyGroup> propertyGroups;
        public IDice Dice { get; private set; }
        private IBanker banker;
        
        public GameBoard(IDice dice)
        {
            Dice = dice;
            locations = new List<Location>();
            propertyGroups = new List<PropertyGroup>();
        }

        public Location GetStartingLocation()
        {
            return locations.FirstOrDefault(l => l.Index == 0);
        }

        public void InitializeBanker(IBanker banker)
        {
            this.banker = banker;
            banker.InitializePropertyGroups(propertyGroups);
        }

        public void AddLocation(Location location)
        {
            if (locations.Count > 40)
                throw new InvalidOperationException("Location can not be added.  Board is full.");

            locations.Add(location);
        }

        public void AddPropertyGroup(PropertyGroup propertyGroup)
        {
            propertyGroups.Add(propertyGroup);
        }

        public virtual void TakeTurnFor(IPlayer player)
        {
            Dice.Roll();
            var diceRoll = Dice.GetCurrentDiceRoll();

            if (Dice.GetCurrentDiceRoll() == 0) return;
            var index = player.Location.Index;

            for (var moved = 1; moved <= diceRoll; moved++)
            {
                index = (index + 1) % locations.Count();
                var location = locations.First(l => l.Index == index);
                
                if (moved == diceRoll)
                {
                    player.LandedOn(location);
                    location.LandedOnBy(player);
                }
                else
                {
                    location.PassedOverBy(player);
                }
            }
        }
    }
}
