using System;

namespace Monopoly
{
    public class MovementResult
    {
        public String Location { get; private set; }
        public Int32 CurrencyGained { get; private set; }

        public MovementResult(String location, Int32 currencyGained)
        {
            this.Location = location;
            this.CurrencyGained = currencyGained;
        }
    }
}
