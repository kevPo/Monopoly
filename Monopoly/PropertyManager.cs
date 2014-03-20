using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Locations.Propertys;

namespace Monopoly
{
    public class PropertyManager : IPropertyManager
    {
        IDictionary<TitleDeed, IPlayer> propertyOwners;

        public PropertyManager()
        {
            propertyOwners = new Dictionary<TitleDeed, IPlayer>();
        }

        public IPlayer GetOwnerFor(Property property)
        {
            var titleDeed = GetTitleDeedFor(property);
            return propertyOwners[titleDeed];
        }

        private TitleDeed GetTitleDeedFor(Property property)
        {
            return propertyOwners.Keys.FirstOrDefault(t => t.Property.Equals(property));
        }

        public Boolean IsPropertyOwned(Property property)
        {
            return propertyOwners.Keys.Any(t => t.Property.Equals(property));
        }

        public void PropertyPurchasedBy(IPlayer player, TitleDeed titleDeed)
        {
            propertyOwners.Add(titleDeed, player);
        }

        public Int32 GetNumberOfOwnedPropertiesInGroupFor(IPlayer owner, Property property)
        {
            var titleDeed = GetTitleDeedFor(property);

            return propertyOwners.Count(p => p.Key.PropertyGroup == titleDeed.PropertyGroup && p.Value.Equals(owner));
        }

        public Int32 GetNumberOfOwnedPropertiesInGroupFor(Property property)
        {
            var titleDeed = GetTitleDeedFor(property);

            return propertyOwners.Count(p => p.Key.PropertyGroup == titleDeed.PropertyGroup);
        }
    }
}
