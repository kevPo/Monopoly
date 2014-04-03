using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Banker;

namespace Monopoly.Locations.Propertys
{
    public class Railroad : Property
    {
        private IEnumerable<Railroad> railroads;

        public Railroad(Int32 index, String name, Int32 cost, Int32 rent, 
                        IBanker banker, IEnumerable<Railroad> railroads)
            : base(index, name, cost, rent, banker)
        {
            this.railroads = railroads;
        }

        protected override Int32 CalculateRent()
        {
            var ownedRailroads = railroads.Where(r => r.IsOwned);
            var numberOfOwnedRailroads = ownedRailroads.Count(r => r.OwnerId.Equals(OwnerId));

            return (Int32) Math.Pow(2, numberOfOwnedRailroads - 1) * rent;
        }

        public Int32 GetRentValue()
        {
            return CalculateRent();
        }
     }
}
