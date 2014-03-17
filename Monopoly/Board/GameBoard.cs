using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Locations;
using Monopoly.PropertyGroups;

namespace Monopoly.Board
{
    public class GameBoard : IBoard
    {
        public IDice Dice { get; private set; }
        private List<Location> locations;
        private List<PropertyGroup> propertyGroups;
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
            var jail = locations.First(l => l.Index == 10);
            var rollCount = 0;

            do
            {
                Dice.Roll();
                rollCount++;

                if (rollCount == 3 && Dice.RollWasDouble())
                    player.LandedOn(jail);
                else
                    MovePlayer(player, Dice.GetCurrentRoll());

            } while (Dice.RollWasDouble() && rollCount < 3);
        }

        private void MovePlayer(IPlayer player, Int32 roll)
        {
            var index = player.Location.Index;

            for (var moved = 1; moved <= roll; moved++)
            {
                index = (index + 1) % locations.Count();
                var location = locations.First(l => l.Index == index);

                if (moved == roll)
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
