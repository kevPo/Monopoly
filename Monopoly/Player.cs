using System;

namespace Monopoly
{
    public class Player
    {
        public Int32 Location { get; set; }
        public String Name { get; private set; }

        public Player(String name)
        {
            Location = 0;
            this.Name = name;
        }

        public void Rolled(Int32 rolled)
        {
            Location += rolled;

            if (Location > 40)
                Location -= 40;
        }
    }
}
