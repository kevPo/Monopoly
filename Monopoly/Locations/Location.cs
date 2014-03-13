using System;

namespace Monopoly.Locations
{
    public abstract class Location
    {
        public Int32 Index { get; private set; }
        public String Name { get; private set; }
        protected Int32 passOverSalary;

        public Location(Int32 index, String name)
        {
            Index = index;
            Name = name;
            passOverSalary = 0;
        }

        public void PassedOverBy(IPlayer player)
        {
            player.ReceiveMoney(passOverSalary);
        }

        public abstract void LandedOnBy(IPlayer player);
    }
}
