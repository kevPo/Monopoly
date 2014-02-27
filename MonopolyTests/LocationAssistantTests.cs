using Monopoly;
using NUnit.Framework;

namespace MonopolyTests
{
    [TestFixture]
    public class LocationAssistantTests
    {
        [Test]
        public void TestGetStartingPositionReturns0()
        {
            var assistant = new LocationAssistant();
            var start = assistant.GetStartingLocation();
            Assert.That(start.Id, Is.EqualTo(0));
        }
    }
}
