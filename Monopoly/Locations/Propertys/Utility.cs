using System;

namespace Monopoly.Locations.Propertys
{
    public class Utility : Property
    {
        private IDice dice;

        public Utility(Int32 index, String name, IBanker banker, IPropertyManager propertyManager, IDice dice)
            : base(index, name, banker, propertyManager)
        {
            this.dice = dice;
        }

        protected override Int32 CalculateRent()
        {
            var utilitiesOwned = propertyManager.GetNumberOfOwnedPropertiesInGroupFor(this);

            if (utilitiesOwned == 1)
                return 4 * dice.GetCurrentRoll();

            return 10 * dice.GetCurrentRoll();
        }
    }
}
