using System;

namespace Monopoly.Locations.Taxable
{
    public abstract class TaxLocation : Location
    {
        protected Func<Int32, Int32> taxEquation { get; set; }

        public TaxLocation(Int32 index, String name) : base(index, name)
        { }

        public override void LandedOnBy(IPlayer player)
        {
            var taxes = taxEquation(player.Balance);
            player.RemoveMoney(taxes);
        }
    }
}
