using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Locations;

namespace Monopoly.PropertyGroups.RentCalculators
{
    public class StreetRentCalculator : RentCalculator
    {
        public override Int32 CalculateRentFor(Property property, IEnumerable<Property> properties)
        {
            var propertiesOwnedByCurrentPropertyOwner = properties.Count(p => p.Owner == property.Owner);
            var oneOwnerOwnsEntireGroup = propertiesOwnedByCurrentPropertyOwner == properties.Count();

            if (oneOwnerOwnsEntireGroup)
                return property.Rent * 2;

            return property.Rent;
        }
    }
}
