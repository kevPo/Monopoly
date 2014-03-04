using Monopoly;
using Monopoly.Assessors;
using NUnit.Framework;

namespace MonopolyTests.AssessorsTests
{
    [TestFixture]
    public class LuxuryTaxAssessorTests
    {
        [Test]
        public void TestLuxuryTaxAssessorTakesAway75DollarsFromPlayer()
        {
            var player = new Player("Horse", 2075, new Board());
            var luxuryTax = new LuxuryTaxAssessor();
            luxuryTax.HandleLocationStopFor(player);
            Assert.That(player.Balance, Is.EqualTo(2000));
        }
    }
}
