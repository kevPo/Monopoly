using System;
using System.Collections.Generic;
using Monopoly.Locations;

namespace Monopoly.PropertyGroups.RentCalculators
{
    public abstract class RentCalculator
    {
        public abstract Int32 CalculateRentFor(Property property, IEnumerable<Property> properties);
    }
}
