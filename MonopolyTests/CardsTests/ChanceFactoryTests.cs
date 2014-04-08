using System.Linq;
using Monopoly.Banker;
using Monopoly.Board;
using Monopoly.Cards;
using Monopoly.JailRoster;
using MonopolyTests.Fakes;
using NUnit.Framework;

namespace MonopolyTests.CardsTests
{
    [TestFixture]
    public class ChanceFactoryTests
    {
        [Test]
        public void TestGetDeckReturnsCardDeck()
        {
            var banker = new TraditionalBanker(new[] { 0, 1 });
            var jailRoster = new TraditionalJailRoster(banker);
            var locationManager = new GameBoard(banker);
            var chanceFactory = new ChanceFactory(banker, jailRoster, locationManager, new FakeDice());

            var deck = chanceFactory.GetCards();
            Assert.That(deck.Count(), Is.EqualTo(16));
        }
    }
}
