using System;
using Monopoly.Locations;

namespace Monopoly
{
    public class Player : IPlayer
    {
        public Location Location { get; private set; }
        public String Name { get; private set; }
        public Int32 Balance { get; private set; }

        public Player(String name, Int32 balance)
        {
            this.Name = name;
            this.Balance = balance;
        }

        public void TakeAwayMoney(Int32 money)
        {
            Balance -= money;
        }

        public void ReceiveMoney(Int32 dollars)
        {
            Balance += dollars;
        }

        public void GoDirectlyTo(Location location)
        {
            Location = location;
        }

        public void LandedOn(Location location)
        {
            Location = location;
            location.LandedOnBy(this);
        }
    }
}
