using System;

namespace Monopoly
{
    public class Player : IPlayer
    {
        public Location Location { get; private set; }
        public String Name { get; private set; }
        private LocationAssistant locationAssistant;

        public Player(String name, LocationAssistant locationAssistant)
        {
            this.Name = name;
            this.locationAssistant = locationAssistant;
        }

        public void TakeTurn(Int32 rolled)
        {
            if (Location == null)
                Location = locationAssistant.GetStartingLocation();

            var id = Location.Id + rolled;

            if (id > 40)
                id -= 40;

            Location = locationAssistant.GetLocationAt(id);
        }
    }
}
