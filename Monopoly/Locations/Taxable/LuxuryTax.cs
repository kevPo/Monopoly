using System;

namespace Monopoly.Locations.Taxable
{
    public class LuxuryTax : TaxLocation
    {
        public LuxuryTax() : base("Luxury Tax")
        {
            taxEquation = LuxuryTaxEquation;
        }

        private Int32 LuxuryTaxEquation(Int32 balance)
        {
            return 75;
        }
    }
}
