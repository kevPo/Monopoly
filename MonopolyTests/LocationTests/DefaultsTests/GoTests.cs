using System;
using Monopoly.Banker;
using Monopoly.Locations.Defaults;
using NUnit.Framework;

namespace MonopolyTests.LocationTests.DefaultsTests
{
    [TestFixture]
    public class GoTests
    {
        private Go starter;
        private Int32 playerId;
        private TraditionalBanker banker;

        [SetUp]
        public void SetUp()
        {
            playerId = 0;
            banker = new TraditionalBanker(new[] { playerId });
            starter = new Go(0, "Go", banker);
        }

        [Test]
        public void TestPlayerReceivesSalaryOf200WhenLandingOnStarter()
        {
            starter.LandedOnBy(playerId);
            Assert.That(banker.GetBalanceFor(playerId), Is.EqualTo(1700));
        }

        [Test]
        public void TestPlayerReceivesSalaryOf200WhenPassedOver()
        {
            starter.PassedOverBy(playerId);
            Assert.That(banker.GetBalanceFor(playerId), Is.EqualTo(1700));
        }
    }
}
