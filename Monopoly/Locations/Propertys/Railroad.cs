using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly.Locations.Propertys
{
    public class Railroad : Property
    {
        private IEnumerable<Railroad> railroads;

        public Railroad(Int32 index, String name, Int32 cost, Int32 rent, IEnumerable<Railroad> railroads)
            : base(index, name, cost, rent)
        {
            this.railroads = railroads;
        }

        protected override Int32 CalculateRent()
        {
            var ownedRailroads = railroads.Where(r => r.IsOwned());
            var numberOfOwnedRailroads = ownedRailroads.Count(r => r.Owner.Equals(Owner));

            return (Int32) Math.Pow(2, numberOfOwnedRailroads - 1) * rent;
        }
     }
}
