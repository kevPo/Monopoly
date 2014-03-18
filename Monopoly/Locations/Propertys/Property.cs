using System;

namespace Monopoly.Locations.Propertys
{
    public abstract class Property : Location
    {
        protected IBanker banker;
        protected IPropertyManager propertyManager;

        public Property(Int32 index, String name, IBanker banker, IPropertyManager propertyManager)
            : base(index, name)
        {
            this.banker = banker;
            this.propertyManager = propertyManager;
        }

        public override void LandedOnBy(IPlayer player)
        {
            if (propertyManager.IsPropertyOwned(this))
            {
                var owner = propertyManager.GetOwnerFor(this);
                
                if (!owner.Equals(player))
                {
                    var rent = CalculateRent();
                    banker.TransferMoney(player, owner, rent);
                }
            }
            else
            {
                if (banker.PlayerCanAffordProperty(player, this))
                    banker.PropertyPurchasedBy(player, this);
            }
        }

        protected abstract Int32 CalculateRent();
    }
}
