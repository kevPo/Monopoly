using System.Collections.Generic;
using Monopoly.Locations;
using Monopoly.PropertyGroups;
namespace Monopoly
{
    public interface IBanker
    {
        void InitializePropertyGroups(IEnumerable<PropertyGroup> propertyGroups);
        void PropertyPurchasedBy(IPlayer player, Property property);
        void PayRentToPropertyOwner(IPlayer player, Property property);
    }
}
