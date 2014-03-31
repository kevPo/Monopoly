using Monopoly.Banker;
using Monopoly.Players;
using MonopolyTests.Fakes;
using NUnit.Framework;

namespace MonopolyTests.LocationTests.PropertysTests
{
    [TestFixture]
    public class PropertyTests
    {
        private IPlayer car;
        private IBanker banker;
        private FakeProperty mediterranean;

        [SetUp]
        public void SetUp()
        {
            car = new Player(0, "car");
            banker = new TraditionalBanker(new[] { car.Id });
            mediterranean = new FakeProperty(1, "Mediterranean Avenue", 60, 2, banker);
        }

        [Test]
        public void TestPlayerLandsOnUnownedPropertyAndBuysIt()
        {
            mediterranean.LandedOnBy(car.Id);
            Assert.That(mediterranean.GetOwner(), Is.EqualTo(car.Id));
        }

        [Test]
        public void TestLandOnPlayerLandsOnOwnedPropertyAndNothingHappens()
        {
            mediterranean.LandedOnBy(car.Id);
            mediterranean.LandedOnBy(car.Id);
            Assert.That(banker.GetBalanceFor(car.Id), Is.EqualTo(1440));
            Assert.That(mediterranean.GetOwner(), Is.EqualTo(car.Id));
        }

        [Test]
        public void PassingOverUnownedPropertyShouldDoNothing()
        {
            mediterranean.PassedOverBy(car.Id);
            Assert.That(banker.GetBalanceFor(car.Id), Is.EqualTo(1500));
        }
    }
}
