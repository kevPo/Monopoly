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
            player = new Player(0, "Horse", 2000);
            var playerRepository = new PlayerRepository(new IPlayer[] { player });
            var playerService = new PlayerService(playerRepository);
            incomeTax = new Taxable(4, "Income Tax", playerService, TestTaxFunction);
        }

        private Int32 TestTaxFunction(Int32 balance)
        {
            return 10;
        }

        [Test]
        public void TestPlayerPaysTaxBasedOnTaxEquation()
        {
            incomeTax.LandedOnBy(player.Id);
            Assert.That(player.Balance, Is.EqualTo(1990));
        }

        [Test]
        public void TestPlayerPassesOverIncomeTaxAndNothingHappens()
        {
            incomeTax.PassedOverBy(player.Id);
            Assert.That(player.Balance, Is.EqualTo(2000));
        }
    }
}
