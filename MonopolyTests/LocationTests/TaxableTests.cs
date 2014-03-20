using System;
using Monopoly;
using Monopoly.Locations;
using NUnit.Framework;

namespace MonopolyTests.LocationTests
{
    [TestFixture]
    public class TaxableTests
    {
        private IPlayer player;
        private Taxable incomeTax;

        [SetUp]
        public void SetUp()
        {
            player = new Player("Horse", 2000);
            incomeTax = new Taxable(4, "Income Tax", TestTaxFunction);
        }

        private Int32 TestTaxFunction(Int32 balance)
        {
            return 10;
        }

        [Test]
        public void TestPlayerPaysTaxBasedOnTaxEquation()
        {
            incomeTax.LandedOnBy(player);
            Assert.That(player.Balance, Is.EqualTo(1990));
        }

        [Test]
        public void TestPlayerPassesOverIncomeTaxAndNothingHappens()
        {
            incomeTax.PassedOverBy(player);
            Assert.That(player.Balance, Is.EqualTo(2000));
        }
    }
}
