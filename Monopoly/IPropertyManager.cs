using System;
using Monopoly.Locations.Propertys;

namespace Monopoly
{
    public interface IPropertyManager
    {
        IPlayer GetOwnerFor(Property property);
        Boolean IsPropertyOwned(Property property);
        void PropertyPurchasedBy(IPlayer player, TitleDeed titleDeed);
        Int32 NumberOfOwnedPropertiesInGroupFor(Property property);
        Int32 NumberOfOwnedPropertiesInGroupFor(IPlayer owner, Property property);
    }
}
