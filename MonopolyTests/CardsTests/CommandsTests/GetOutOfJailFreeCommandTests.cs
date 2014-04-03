using Monopoly.Banker;
using Monopoly.Cards.Commands;
using Monopoly.JailRoster;
using NUnit.Framework;

namespace MonopolyTests.CardsTests.CommandsTests
{
    [TestFixture]
    public class GetOutOfJailFreeCommandTests : CommandTests
    {
        [Test]
        public void TestGetOutOfJailCommandReleasesPlayerFromJail()
        {
            jailRoster.Add(playerOneId);
            var getOutOfJailFreeCommand = new GetOutOfJailFreeCommand(jailRoster);

            getOutOfJailFreeCommand.PerformOn(playerOneId);
            Assert.That(jailRoster.IsInJail(playerOneId), Is.False);
            Assert.That(banker.GetBalanceFor(playerOneId), Is.EqualTo(1500));
        }
    }
}
