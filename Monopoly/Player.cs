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
            Name = name;
            Balance = balance;
        }

        public void RemoveMoney(Int32 money)
        {
            Balance -= money;
        }

        public void ReceiveMoney(Int32 dollars)
        {
            Balance += dollars;
        }

        public void LandedOn(Location location)
        {
            Location = location;
        }

        public override Boolean Equals(object other)
        {
            if (other.GetType() != typeof(Player))
                return false;
            else
                return Equals((Player)other);
        }

        public Boolean Equals(Player other)
        {
            return Name == other.Name;
        }

        public override Int32 GetHashCode()
        {
            return (Name.GetHashCode() ^ 2) * 17;
        }
    }
}
