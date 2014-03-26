using System;

namespace Monopoly.Locations
{
    public class Taxable : Location
    {
        private Func<Int32, Int32> taxEquation;

        public Taxable(Int32 index, String name, IPlayerService playerService, Func<Int32, Int32> taxEquation) 
            : base(index, name, playerService)
        {
            this.taxEquation = taxEquation;
        }

        public override void LandedOnBy(Int32 playerId)
        {
            playerService.ChargeTaxesTo(playerId, taxEquation);
        }
    }
}
