using System;

namespace Monopoly
{
    public class Player : IPlayer
    {
        public Location Location { get; private set; }
        public String Name { get; private set; }
        public Int32 Balance { get; private set; }
        private LocationAssistant locationAssistant;

        public Player(String name, LocationAssistant locationAssistant)
        {
            this.Name = name;
            this.locationAssistant = locationAssistant;
        }

        public void TakeTurn(Int32 rolled)
        {
            InitializeIfFirstTurn();
            var id = Location.Id + rolled;

            if (id > 39)
                id -= 40;

            Location = locationAssistant.GetLocationAt(id);
            
            if (Location.Name == "Go")
                Balance += 200;
        }

        private void InitializeIfFirstTurn()
        {
            if (Location == null)
            {
                Location = locationAssistant.GetStartingLocation();
                Balance = 0;
            }
        }
    }
}
