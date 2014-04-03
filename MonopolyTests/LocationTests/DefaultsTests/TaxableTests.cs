using System;
using Monopoly.Banker;
using Monopoly.Locations.Defaults;
using NUnit.Framework;

namespace MonopolyTests.LocationTests.DefaultsTests
{
    [TestFixture]
    public class TaxableTests
    {
        private Int32 playerId;
        private Taxable incomeTax;
        private IBanker banker;

        [SetUp]
        public void SetUp()
        {
            playerId = 0;
            banker = new TraditionalBanker(new[] { playerId });
            incomeTax = new Taxable(4, "Income Tax", banker, TestTaxFunction);
        }

        private Int32 TestTaxFunction(Int32 balance)
        {
            return 10;
        }

        [Test]
        public void TestPlayerPaysTaxBasedOnTaxEquation()
        {
            incomeTax.LandedOnBy(playerId);
            Assert.That(banker.GetBalanceFor(playerId), Is.EqualTo(1490));
        }

        [Test]
        public void TestPlayerPassesOverIncomeTaxAndNothingHappens()
        {
            incomeTax.PassedOverBy(playerId);
            Assert.That(banker.GetBalanceFor(playerId), Is.EqualTo(1500));
        }
    }
}
