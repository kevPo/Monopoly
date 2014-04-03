using System;
using Monopoly.Banker;

namespace Monopoly.Locations.Defaults
{
    public abstract class Location
    {
        public Int32 Index { get; private set; }
        public String Name { get; private set; }
        protected IBanker banker;
        protected Int32 passOverSalary;

        public Location(Int32 index, String name, IBanker banker)
        {
            Index = index;
            Name = name;
            this.banker = banker;
            passOverSalary = 0;
        }

        public void PassedOverBy(Int32 playerId)
        {
            if (passOverSalary > 0)
                banker.PayMoneyTo(playerId, passOverSalary);
        }

        public abstract void LandedOnBy(Int32 playerId);
    }
}
