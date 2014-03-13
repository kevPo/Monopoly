using System;

namespace Monopoly.Locations.Taxable
{
    public class IncomeTax : TaxLocation
    {
        public IncomeTax(Int32 index, String name) : base(index, name)
        {
            taxEquation = IncomeTaxEquation;
        }

        private Int32 IncomeTaxEquation(Int32 balance)
        {
            return balance > 2000 ? 200 : Convert.ToInt32(balance * .1);
        }
    }
}
