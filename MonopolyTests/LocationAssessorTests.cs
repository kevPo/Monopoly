using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly;
using NUnit.Framework;

namespace MonopolyTests
{
    [TestFixture]
    public class LocationAssessorTests
    {
        [Test]
        public void TestIncomeTaxReturnsNegative10PercentOfPlayerBalance()
        {
            var assessor = new LocationAssessor();
            Assert.That(assessor.GetAssesmentFor("Income Tax", 1800), Is.EqualTo(-180));            
        }
    }
}
