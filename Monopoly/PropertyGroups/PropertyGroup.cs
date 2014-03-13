using System;
using System.Collections.Generic;
using Monopoly.Locations;
using Monopoly.PropertyGroups.RentCalculators;

namespace Monopoly.PropertyGroups
{
    public class PropertyGroup
    {
        public String Name { get; private set; }
        public IEnumerable<Property> Properties { get; private set; }
        public RentCalculator RentCalculator { get; private set; }
        public HashSet<Int32> Indexes { get; private set; }

        public PropertyGroup(String name, IEnumerable<Property> properties, RentCalculator rentCalculator)
        {
            Name = name;
            Properties = properties;
            RentCalculator = rentCalculator;
            SetIndexes();
        }

        private void SetIndexes()
        {
            Indexes = new HashSet<Int32>();

            foreach (var property in Properties)
                Indexes.Add(property.Index);
        }
    }
}
