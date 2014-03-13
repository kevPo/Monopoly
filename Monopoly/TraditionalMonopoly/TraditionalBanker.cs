using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Locations;
using Monopoly.PropertyGroups;

namespace Monopoly.TraditionalMonopoly
{
    public class TraditionalBanker : IBanker
    {
        private IEnumerable<PropertyGroup> propertyGroups;

        public void InitializePropertyGroups(IEnumerable<PropertyGroup> propertyGroups)
        {
            this.propertyGroups = propertyGroups;
        }

        public void PropertyPurchasedBy(IPlayer player, Property property)
        {
            player.RemoveMoney(property.Cost);
        }

        public void PayRentToPropertyOwner(IPlayer player, Property property)
        {
            Int32 rent;

            if (propertyGroups == null)
            {
                rent = property.Rent;
            }
            else
            {
                var propertyGroup = propertyGroups.FirstOrDefault(p => p.Indexes.Contains(property.Index));
                rent = propertyGroup == null ? rent = property.Rent : 
                    propertyGroup.RentCalculator.CalculateRentFor(property, propertyGroup.Properties);
            }
            
            player.RemoveMoney(rent);
            property.Owner.ReceiveMoney(rent);
        }
    }
}
