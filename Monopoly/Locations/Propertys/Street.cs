using System;

namespace Monopoly.Locations.Propertys
{
    public class Street : Property
    {
        public Street(Int32 index, String name, IBanker banker, IPropertyManager propertyManager)
            : base(index, name, banker, propertyManager)
        {}

        protected override Int32 CalculateRent()
        {
            var owner = propertyManager.GetOwnerFor(this);
            var numberOfPropertiesInGroup = banker.NumberOfPropertiesInGroupFor(this);
            var numberOfOwnedGroupProperties = propertyManager.GetNumberOfOwnedPropertiesInGroupFor(owner, this);
            var oneOwnerOwnsEntireGroup = numberOfPropertiesInGroup == numberOfOwnedGroupProperties;
            var rent = banker.GetRentFor(this);

            if (oneOwnerOwnsEntireGroup)
                return rent * 2;

            return rent;
        }
    }
}
