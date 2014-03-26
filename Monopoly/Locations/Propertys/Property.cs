using System;

namespace Monopoly.Locations.Propertys
{
    public abstract class Property : Location
    {
        protected Int32 ownerId { get; private set; }
        protected Boolean isOwned;
        protected Int32 rent;
        private Int32 cost;

        public Property(Int32 index, String name, Int32 cost, Int32 rent, IPlayerService playerService)
            : base(index, name, playerService)
        {
            this.rent = rent;
            this.cost = cost;
            isOwned = false;
        }

        public override void LandedOnBy(Int32 playerId)
        {
            if (isOwned)
                HandleLandingWhenOwned(playerId);
            else
                SellPropertyToPlayerIfAffordable(playerId);
        }

        private void SellPropertyToPlayerIfAffordable(Int32 playerId)
        {
            if (cost < playerService.GetBalanceFor(playerId))
            {
                playerService.RemoveMoneyFrom(playerId, cost);
                ownerId = playerId;
                isOwned = true;
            }
        }

        private void HandleLandingWhenOwned(Int32 playerId)
        {
            if (playerId != ownerId)
                ChargeRent(playerId, ownerId);
        }

        private void ChargeRent(Int32 playerId, Int32 ownerId)
        {
            playerService.TransferMoney(playerId, ownerId, CalculateRent());
        }

        protected abstract Int32 CalculateRent();
    }
}
