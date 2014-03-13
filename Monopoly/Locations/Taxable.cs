using System;
using Monopoly.Locations;

namespace Monopoly.Locations
{
    public class Taxable : Location
    {
        private Func<Int32, Int32> taxEquation;

        public Taxable(Int32 index, String name, Func<Int32, Int32> taxEquation) : base(index, name)
        {
            this.taxEquation = taxEquation;
        }

        public override void LandedOnBy(IPlayer player)
        {
            var taxes = taxEquation(player.Balance);
            player.RemoveMoney(taxes);
        }
    }
}
