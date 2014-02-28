using Monopoly;
using NUnit.Framework;

namespace MonopolyTests
{
    [TestFixture]
    public class BoardTests
    {
        [Test]
        public void TestGetStartingPositionReturnsGo()
        {
            var board = new Board();
            var start = board.GetStartingLocation();
            Assert.That(start, Is.EqualTo("Go"));
        }
    }
}
