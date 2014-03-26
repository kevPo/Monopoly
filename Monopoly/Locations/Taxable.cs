using System;

namespace Monopoly.Locations
{
    public class Taxable : Location
    {
        private Func<Int32, Int32> taxEquation;

        public Taxable(Int32 index, String name, IPlayerRepository playerRepository, Func<Int32, Int32> taxEquation) 
            : base(index, name, playerRepository)
        {
            this.taxEquation = taxEquation;
        }

        public override void LandedOnBy(Int32 playerId)
        {
            playerRepository.ChargeTaxesTo(playerId, taxEquation);
        }
    }
}
