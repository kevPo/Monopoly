using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Locations;

namespace Monopoly.PropertyGroups.RentCalculators
{
    public class RailroadRentCalculator : RentCalculator
    {
        public override Int32 CalculateRentFor(Property property, IEnumerable<Property> properties)
        {
            var ownedRailroadsOfCurrentOwner = properties.Count(p => p.Owner == property.Owner);

            switch (ownedRailroadsOfCurrentOwner)
            {
                case 1:
                    return 25;
                case 2:
                    return 50;
                case 3:
                    return 100;
                case 4:
                    return 200;
                default:
                    return 0;
            }
        }
    }
}
