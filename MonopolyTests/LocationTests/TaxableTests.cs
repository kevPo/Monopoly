using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly;
using Monopoly.Locations;
using NUnit.Framework;

namespace MonopolyTests.LocationTests
{
    [TestFixture]
    public class TaxableTests
    {
        private Int32 TestTaxFunction(Int32 balance)
        {
            return 10;
        }

        [Test]
        public void TestPlayerPaysTaxBasedOnTaxEquation()
        {
            var incomeTax = new Taxable(4, "Income Tax", TestTaxFunction);
            var player = new Player("Horse", 2000);
            incomeTax.LandedOnBy(player);
            Assert.That(player.Balance, Is.EqualTo(1990));
        }
    }
}
