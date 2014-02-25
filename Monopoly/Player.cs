using System;

namespace Monopoly
{
    public class Player
    {
        public Int32 Location { get; set; }

        public Player()
        {
            Location = 0;
        }

        public void Rolled(Int32 rolled)
        {
            Location += rolled;

            if (Location > 40)
                Location -= 40;
        }
    }
}
