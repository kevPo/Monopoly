using System.Collections.Generic;
using Monopoly;
using Monopoly.Locations;
using Monopoly.PropertyGroups;

namespace MonopolyTests.Fakes
{
    public class FakeBanker : IBanker
    {
        public void InitializePropertyGroups(IEnumerable<PropertyGroup> propertyGroups)
        {}

        public void PropertyPurchasedBy(IPlayer player, Property property)
        {}

        public void PayRentToPropertyOwner(IPlayer player, Property property)
        {}
    }
}
