using System;

namespace Monopoly
{
    public class Player : IPlayer
    {
        public Int32 Location { get; set; }
        public String Name { get; private set; }

        public Player(String name)
        {
            this.Name = name;
        }

        public void Rolled(Int32 rolled)
        {
            Location += rolled;

            if (Location > 40)
                Location -= 40;
        }

        public void TakeTurn()
        {
            var randomDice = new Random();
            Rolled(randomDice.Next(2, 13));
        }
    }
}
