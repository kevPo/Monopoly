using System;

namespace Monopoly.Locations.Taxable
{
    public abstract class TaxLocation : Location
    {
        protected Func<Int32, Int32> taxEquation { get; set; }

        public TaxLocation(String name) : base(name)
        { }

        public override void LandedOnBy(IPlayer player)
        {
            var taxes = taxEquation(player.Balance);
            player.TakeAwayMoney(taxes);
        }
    }
}
