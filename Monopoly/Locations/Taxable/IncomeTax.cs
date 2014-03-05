using System;

namespace Monopoly.Locations.Taxable
{
    public class IncomeTax : TaxLocation
    {
        public IncomeTax() : base("Income Tax")
        {
            taxEquation = IncomeTaxEquation;
        }

        private Int32 IncomeTaxEquation(Int32 balance)
        {
            return balance > 2000 ? 200 : Convert.ToInt32(balance * .1);
        }
    }
}
