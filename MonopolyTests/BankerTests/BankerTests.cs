using System;
using Monopoly.Banker;
using NUnit.Framework;

namespace MonopolyTests.BankerTests
{
    [TestFixture]
    public class TraditionalBankerTests
    {
        private TraditionalBanker banker;

        [SetUp]
        public void SetUp()
        {
            banker = new TraditionalBanker(new[] { 0, 1 });
        }

        [Test]
        public void TestThatPlayersAreInitiatedWith1500()
        {
            Assert.That(banker.GetBalanceFor(0), Is.EqualTo(1500));
            Assert.That(banker.GetBalanceFor(1), Is.EqualTo(1500));
        }

        [Test]
        public void TestRemove100FromPlayerSetBalanceTo1400()
        {
            banker.CollectMoneyFrom(0, 100);

            Assert.That(banker.GetBalanceFor(0), Is.EqualTo(1400));
        }

        [Test]
        public void TestAdd100ToPlayerAdds100ToBalance()
        {
            banker.PayMoneyTo(0, 100);

            Assert.That(banker.GetBalanceFor(0), Is.EqualTo(1600));
        }

        [Test]
        public void TestChargeTenDollarTaxFunctionChargesRemovesTenFromBalance()
        {
            banker.ChargeTaxesTo(0, TaxEquation);

            Assert.That(banker.GetBalanceFor(0), Is.EqualTo(1490));
        }

        private Int32 TaxEquation(Int32 balance)
        {
            return 10;
        }

        [Test]
        public void TestTransfer100FromOnePlayerToAnotherSuccessfully()
        {
            banker.TransferMoney(0, 1, 100);

            Assert.That(banker.GetBalanceFor(0), Is.EqualTo(1400));
            Assert.That(banker.GetBalanceFor(1), Is.EqualTo(1600));
        }
    }
}
