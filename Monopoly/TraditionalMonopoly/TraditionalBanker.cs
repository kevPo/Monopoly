using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Locations.Propertys;

namespace Monopoly.TraditionalMonopoly
{
    public class TraditionalBanker : IBanker
    {
        private IEnumerable<TitleDeed> titleDeeds;
        private IPropertyManager propertyManager;

        public TraditionalBanker(IEnumerable<TitleDeed> titleDeeds, IPropertyManager propertyManager)
        {
            this.titleDeeds = titleDeeds;
            this.propertyManager = propertyManager;
        }

        public void PropertyPurchasedBy(IPlayer player, Property property)
        {
            var propertyDeed = titleDeeds.FirstOrDefault(d => d.Property.Equals(property));
            player.RemoveMoney(propertyDeed.Cost);
            propertyManager.PropertyPurchasedBy(player, propertyDeed);
        }

        public void TransferMoney(IPlayer payingPlayer, IPlayer receivingPlayer, Int32 money)
        {
            payingPlayer.RemoveMoney(money);
            receivingPlayer.ReceiveMoney(money);
        }

        public Int32 GetRentFor(Property property)
        {
            return titleDeeds.First(d => d.Property.Equals(property)).Rent;
        }

        public Boolean PlayerCanAffordProperty(IPlayer player, Property property)
        {
            var propertyDeed = titleDeeds.FirstOrDefault(d => d.Property.Equals(property));

            return propertyDeed.Cost < player.Balance;
        }

        public Int32 NumberOfPropertiesInGroupFor(Property property)
        {
            var titleDeed = titleDeeds.FirstOrDefault(d => d.Property.Equals(property));

            return titleDeeds.Count(d => d.PropertyGroup == titleDeed.PropertyGroup);
        }
    }
}
