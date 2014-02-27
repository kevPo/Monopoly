using System;

namespace Monopoly
{
    public class Player : IPlayer
    {
        public Int32 Location { get; private set; }
        public String Name { get; private set; }

        public Player(String name)
        {
            this.Name = name;
        }

        public void TakeTurn(Int32 rolled)
        {
            Location += rolled;

            if (Location > 40)
                Location -= 40;
        }
    }
}
