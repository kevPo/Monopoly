using System;
using Monopoly;
using Monopoly.Locations.Propertys;

namespace MonopolyTests.Fakes
{
    public class FakeBanker : IBanker
    {

        public void PropertyPurchasedBy(IPlayer player, Property property)
        {}

        public void TransferMoney(IPlayer payingPlayer, IPlayer receivingPlayer, Int32 money)
        {}

        public Int32 GetRentFor(Property property)
        {
            return 0;
        }

        public Boolean PlayerCanAffordProperty(IPlayer player, Property property)
        {
            return false;
        }

        public Int32 NumberOfPropertiesInGroupFor(Property property)
        {
            return 0;
        }
    }
}
