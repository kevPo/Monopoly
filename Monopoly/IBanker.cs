using System;
using Monopoly.Locations.Propertys;

namespace Monopoly
{
    public interface IBanker
    {
        void PropertyPurchasedBy(IPlayer player, Property property);
        void TransferMoney(IPlayer payingPlayer, IPlayer receivingPlayer, Int32 money);
        Int32 GetRentFor(Property property);
        Boolean PlayerCanAffordProperty(IPlayer player, Property property);
        Int32 NumberOfPropertiesInGroupFor(Property property);
    }
}
