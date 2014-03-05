using System;

namespace Monopoly.Locations
{
    public abstract class Location
    {
        public String Name { get; private set; }
        protected Int32 passOverSalary;

        public Location(String name)
        {
            this.Name = name;
            this.passOverSalary = 0;
        }
        
        public void PassedOverBy(IPlayer player)
        {
            player.ReceiveMoney(passOverSalary);
        }

        public abstract void LandedOnBy(IPlayer player);
    }
}
