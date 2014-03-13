using System;

namespace Monopoly.Locations.Taxable
{
    public class LuxuryTax : TaxLocation
    {
        public LuxuryTax(Int32 index, String name) : base(index, name)
        {
            taxEquation = LuxuryTaxEquation;
        }

        private Int32 LuxuryTaxEquation(Int32 balance)
        {
            return 75;
        }
    }
}
