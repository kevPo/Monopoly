using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly.Locations.Propertys
{
    public class Street : Property
    {
        private IEnumerable<Street> sisterStreets;

        public Street(Int32 index, String name, Int32 cost, Int32 rent, IEnumerable<Street> sisterStreets)
            : base(index, name, cost, rent)
        {
            this.sisterStreets = sisterStreets;
        }

        protected override Int32 CalculateRent()
        {
            var numberOfPropertiesInGroup = sisterStreets.Count();
            var ownedStreets = sisterStreets.Where(s => s.IsOwned());
            var numberOfOwnedGroupProperties = ownedStreets.Count(s => s.Owner.Equals(Owner));
            var oneOwnerOwnsEntireGroup = numberOfPropertiesInGroup == numberOfOwnedGroupProperties;

            if (oneOwnerOwnsEntireGroup)
                return rent * 2;

            return rent;
        }
    }
}
