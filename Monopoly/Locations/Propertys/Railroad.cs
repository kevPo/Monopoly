using System;

namespace Monopoly.Locations.Propertys
{
    public class Railroad : Property
    {
        public Railroad(Int32 index, String name, IBanker banker, IPropertyManager propertyManager)
            : base(index, name, banker, propertyManager)
        {}

        protected override Int32 CalculateRent()
        {
            var owner = propertyManager.GetOwnerFor(this);
            var numberOfOwnedRailroads = propertyManager.NumberOfOwnedPropertiesInGroupFor(owner, this);

            return (Int32) Math.Pow(2, numberOfOwnedRailroads - 1) * banker.GetRentFor(this);
        }
     }
}
