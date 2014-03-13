using System;

namespace Monopoly.Locations
{
    public class Property : Location
    {
        public Int32 Cost { get; private set; }
        public Int32 Rent { get; private set; }
        public IPlayer Owner { get; private set; }
        private IBanker banker;

        public Property(Int32 index, String name, Int32 cost, Int32 rent, IBanker banker) : base(index, name)
        {
            Cost = cost;
            Rent = rent;
            this.banker = banker;
        }

        public override void LandedOnBy(IPlayer player)
        {
            var propertyIsAvailableAndAffordableForPlayer = Owner == null && player.Balance > Cost;
            var propertyIsOwnedByAnotherPlayer = Owner != null && Owner != player;

            if (propertyIsAvailableAndAffordableForPlayer)
            {
                banker.PropertyPurchasedBy(player, this);
                Owner = player;
            }
            else if (propertyIsOwnedByAnotherPlayer)
            {
                banker.PayRentToPropertyOwner(player, this);
            }
        }
    }
}
