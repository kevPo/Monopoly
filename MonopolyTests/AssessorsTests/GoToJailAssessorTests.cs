using Monopoly;
using Monopoly.Assessors;
using NUnit.Framework;

namespace MonopolyTests.AssessorsTests
{
    [TestFixture]
    public class GoToJailAssessorTests
    {
        [Test]
        public void TestGoToJailAssessorSendsPlayerToJail()
        {
            var player = new Player("Horse", 100, new Board());
            var goToJail = new GoToJailAssessor();
            goToJail.HandleLocationStopFor(player);
            Assert.That(player.Location.Name, Is.EqualTo("Jail/ Just Visiting"));
            Assert.That(player.Balance, Is.EqualTo(100));
        }
    }
}
