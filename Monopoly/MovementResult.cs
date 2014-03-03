using System;

namespace Monopoly
{
    public class MovementResult
    {
        public String Location { get; private set; }
        public Int32 Balance { get; private set; }

        public MovementResult(String location, Int32 balance)
        {
            this.Location = location;
            this.Balance = balance;
        }
    }
}
