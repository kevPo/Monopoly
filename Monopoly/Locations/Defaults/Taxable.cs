using System;
using Monopoly.Banker;

namespace Monopoly.Locations.Defaults
{
    public class Taxable : Location
    {
        private Func<Int32, Int32> taxEquation;
        private IBanker banker;

        public Taxable(Int32 index, String name, IBanker banker, Func<Int32, Int32> taxEquation)
            : base(index, name)
        {
            this.taxEquation = taxEquation;
            this.banker = banker;
        }

        public override void LandedOnBy(Int32 playerId)
        {
            banker.ChargeTaxesTo(playerId, taxEquation);
        }
    }
}
