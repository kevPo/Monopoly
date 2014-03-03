using Monopoly;
using NUnit.Framework;

namespace MonopolyTests
{
    [TestFixture]
    public class LocationAssessorTests
    {
        private LocationAssessor assessor;

        [SetUp]
        public void SetUp()
        {
            assessor = new LocationAssessor();
        }

        [Test]
        public void TestLandOnGoToJailVisitsJailAndBalanceRemainsTheSame()
        {
            var result = assessor.GetAssesmentFor("Go To Jail", 1800);
            Assert.That(result.Location, Is.EqualTo("Jail/ Just Visiting"));
            Assert.That(result.Balance, Is.EqualTo(1800));
        }

        [Test]
        public void TestIncomeTaxDecreasesBalanceBy10PercentWhenLessThan2000()
        {
            var result = assessor.GetAssesmentFor("Income Tax", 1800);
            Assert.That(result.Balance, Is.EqualTo(1620));            
        }

        [Test]
        public void TestIncomeTaxDecreasesBalanceBy200WhenBalanceIsOver2000()
        {
            var result = assessor.GetAssesmentFor("Income Tax", 2200);
            Assert.That(result.Balance, Is.EqualTo(2000));            
        }

        [Test]
        public void TestIncomeTaxDoesNotChangeBalanceForZeroBalance()
        {
            var result = assessor.GetAssesmentFor("Income Tax", 0);
            Assert.That(result.Balance, Is.EqualTo(0));
        }

        [Test] 
        public void TestIncomeTaxDecreasesBalanceBy200ForBalanceOf2000()
        {
            var result = assessor.GetAssesmentFor("Income Tax", 2000);
            Assert.That(result.Balance, Is.EqualTo(1800));
        }

        [Test]
        public void TestLuxuryTaxDecreasesBalanceBy75()
        {
            var result = assessor.GetAssesmentFor("Luxury Tax", 175);
            Assert.That(result.Balance, Is.EqualTo(100));
        }
    }
}
