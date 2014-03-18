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

            switch (numberOfOwnedRailroads)
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
