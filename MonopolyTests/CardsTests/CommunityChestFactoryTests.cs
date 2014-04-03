using System.Linq;
using Monopoly.Banker;
using Monopoly.Board;
using Monopoly.Cards;
using Monopoly.JailRoster;
using NUnit.Framework;

namespace MonopolyTests.CardsTests
{
    [TestFixture]
    public class CommunityChestFactoryTests
    {
        [Test]
        public void TestGetDeckReturnsACardDeck()
        {
            var banker = new TraditionalBanker(new[] { 0, 1 });
            var jailRoster = new TraditionalJailRoster(banker);
            var locationManager = new GameBoard();
            var communityChestFactory = new CommunityChestFactory(banker, jailRoster, locationManager);

            var deck = communityChestFactory.GetCards();
            Assert.That(deck.Count(), Is.EqualTo(16));
        }
    }
}
