using System;

namespace Monopoly.Locations.Propertys
{
    public abstract class Property : Location
    {
        public IPlayer Owner { get; private set; }

        protected Int32 rent;
        private Int32 cost;

        public Property(Int32 index, String name, Int32 cost, Int32 rent)
            : base(index, name)
        {
            this.rent = rent;
            this.cost = cost;
        }

        public Boolean IsOwned()
        {
            return Owner != null;
        }

        public override void LandedOnBy(IPlayer player)
        {
            if (IsOwned())
                HandleLandingWhenOwned(player);
            else
                SellPropertyToPlayerIfAffordable(player);
        }

        private void SellPropertyToPlayerIfAffordable(IPlayer player)
        {
            if (cost < player.Balance)
            {
                player.RemoveMoney(cost);
                Owner = player;
            }
        }

        private void HandleLandingWhenOwned(IPlayer player)
        {
            if (!player.Equals(Owner))
                ChargeRent(player, Owner);
        }

        private void ChargeRent(IPlayer player, IPlayer owner)
        {
            var rent = CalculateRent();
            player.RemoveMoney(rent);
            owner.ReceiveMoney(rent);
        }

        protected abstract Int32 CalculateRent();
    }
}
