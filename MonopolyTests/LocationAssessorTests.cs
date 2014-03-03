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
        public void TestIncomeTaxReturnsNegative10PercentOfPlayerBalance()
        {
            
            Assert.That(assessor.GetAssesmentFor("Income Tax", 1800), Is.EqualTo(-180));            
        }

        [Test]
        public void TestIncomeTaxReturnsNegative200WhenBalanceIsOver2000()
        {
            Assert.That(assessor.GetAssesmentFor("Income Tax", 2200), Is.EqualTo(-200));            
        }

        [Test]
        public void TestIncomeTaxReturnsZeroForZeroBalance()
        {
            Assert.That(assessor.GetAssesmentFor("Income Tax", 0), Is.EqualTo(0));
        }

        [Test] 
        public void TestIncomeTaxReturnsNegative200ForBalanceOf2000()
        {
            Assert.That(assessor.GetAssesmentFor("Income Tax", 2000), Is.EqualTo(-200));
        }
    }
}
