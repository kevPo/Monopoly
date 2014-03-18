using System;
using Monopoly.Locations.Propertys;

namespace Monopoly
{
    public class TitleDeed
    {
        public Property Property { get; private set; }
        public Int32 Cost { get; private set; }
        public Int32 Rent { get; private set; }
        public PropertyGroup PropertyGroup { get; private set; }

        public TitleDeed(Property property, Int32 cost, Int32 rent, PropertyGroup propertyGroup)
        {
            Property = property;
            Cost = cost;
            Rent = rent;
            PropertyGroup = propertyGroup;
        }
    }
}
