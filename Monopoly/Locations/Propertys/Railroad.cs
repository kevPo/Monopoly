using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly.Locations.Propertys
{
    public class Railroad : Property
    {
        private IEnumerable<Railroad> railroads;

        public Railroad(Int32 index, String name, Int32 cost, Int32 rent, 
                        IPlayerRepository playerRepository, IEnumerable<Railroad> railroads)
            : base(index, name, cost, rent, playerRepository)
        {
            this.railroads = railroads;
        }

        protected override Int32 CalculateRent()
        {
            var ownedRailroads = railroads.Where(r => r.isOwned);
            var numberOfOwnedRailroads = ownedRailroads.Count(r => r.ownerId.Equals(ownerId));

            return (Int32) Math.Pow(2, numberOfOwnedRailroads - 1) * rent;
        }
     }
}
