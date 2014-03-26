using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly.Locations.Propertys
{
    public class Street : Property
    {
        private IEnumerable<Street> sisterStreets;

        public Street(Int32 index, String name, Int32 cost, Int32 rent, IPlayerRepository playerRepository, IEnumerable<Street> sisterStreets)
            : base(index, name, cost, rent, playerRepository)
        {
            this.sisterStreets = sisterStreets;
        }

        protected override Int32 CalculateRent()
        {
            var numberOfPropertiesInGroup = sisterStreets.Count();
            var ownedStreets = sisterStreets.Where(s => s.isOwned);
            var numberOfOwnedGroupProperties = ownedStreets.Count(s => s.ownerId.Equals(ownerId));
            var oneOwnerOwnsEntireGroup = numberOfPropertiesInGroup == numberOfOwnedGroupProperties;

            if (oneOwnerOwnsEntireGroup)
                return rent * 2;

            return rent;
        }
    }
}
