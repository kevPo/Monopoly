using System;

namespace Monopoly
{
    public class MovementResult
    {
        public Location Location { get; private set; }
        public Int32 Balance { get; private set; }

        public MovementResult(Location location, Int32 balance)
        {
            this.Location = location;
            this.Balance = balance;
        }
    }
}
