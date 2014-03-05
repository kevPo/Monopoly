using System;

namespace Monopoly.Locations
{
    public class Property : Location
    {
        public Int32 Cost { get; private set; }
        public IPlayer Owner { get; private set; }

        public Property(String name, Int32 cost) : base(name)
        {
            this.Cost = cost;
        }

        public override void LandedOnBy(IPlayer player)
        {
            if (Owner == null && player.Balance > Cost)
            {
                player.TakeAwayMoney(Cost);
                Owner = player;
            }
        }

        public void BoughtBy(IPlayer player)
        {
            Owner = player;
        }
    }
}
