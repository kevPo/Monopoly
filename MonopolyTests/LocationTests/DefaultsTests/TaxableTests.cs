using System;
using Monopoly.Banker;
using Monopoly.Locations.Defaults;
using Monopoly.Players;
using NUnit.Framework;

namespace MonopolyTests.LocationTests.DefaultsTests
{
    [TestFixture]
    public class TaxableTests
    {
        private IPlayer player;
        private Taxable incomeTax;
        private IBanker banker;

        [SetUp]
        public void SetUp()
        {
            player = new Player(0, "Horse");
            var playerRepository = new PlayerRepository(new IPlayer[] { player });
            banker = new TraditionalBanker(playerRepository.GetPlayerIds());
            incomeTax = new Taxable(4, "Income Tax", banker, TestTaxFunction);
        }

        private Int32 TestTaxFunction(Int32 balance)
        {
            return 10;
        }

        [Test]
        public void TestPlayerPaysTaxBasedOnTaxEquation()
        {
            incomeTax.LandedOnBy(player.Id);
            Assert.That(banker.GetBalanceFor(player.Id), Is.EqualTo(1490));
        }

        [Test]
        public void TestPlayerPassesOverIncomeTaxAndNothingHappens()
        {
            incomeTax.PassedOverBy(player.Id);
            Assert.That(banker.GetBalanceFor(player.Id), Is.EqualTo(1500));
        }
    }
}
