using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Locations;

namespace Monopoly.PropertyGroups.RentCalculators
{
    public class UtilityRentCalculator : RentCalculator
    {
        private IDice dice;

        public UtilityRentCalculator(IDice dice)
        {
            this.dice = dice;
        }

        public override Int32 CalculateRentFor(Property property, IEnumerable<Property> properties)
        {
            var propertiesOwned = properties.Count(p => p.Owner != null);

            if (propertiesOwned == 1)
                return 4 * dice.GetCurrentRoll();

            return 10 * dice.GetCurrentRoll();
        }
    }
}
