using Monopoly;
using Monopoly.Locations;
using Monopoly.PropertyGroups;
using Monopoly.PropertyGroups.RentCalculators;
using Monopoly.TraditionalMonopoly;
using NUnit.Framework;

namespace MonopolyTests.TraditionalMonopolyTests
{
    [TestFixture]
    public class TraditionalBankerTests
    {
        private IBanker banker;
        private IPlayer car;
        private IPlayer horse;
        private Property railroad;

        [SetUp]
        public void SetUp()
        {
            banker = new TraditionalBanker();
            car = new Player("car", 2000);
            horse = new Player("horse", 2000);
            railroad = new Property(5, "Reading Railroad", 200, 25, banker);
        }

        [Test]
        public void TestPropertyPurchasedByPlayerRemovesMoneyFromPlayer()
        {
            banker.PropertyPurchasedBy(car, railroad);
            Assert.That(car.Balance, Is.EqualTo(1800));
        }

        [Test]
        public void TestPayRentToPropertyOwnerPaysRentOfPropertyWhenNoGroupIsFound()
        {
            railroad.LandedOnBy(car);

            banker.PayRentToPropertyOwner(horse, railroad);
            Assert.That(car.Balance, Is.EqualTo(1825));
            Assert.That(horse.Balance, Is.EqualTo(1975));
        }

        [Test]
        public void TestPayRentToPropertyOwnerInActualGroupChargesCorrectRent()
        {
            var medAve = new Property(1, "Mediterranean Avenue", 60, 2, banker);
            var balticAve = new Property(3, "Baltic Avenue", 60, 4, banker);
            var purpleStreets = new Property[] { medAve, balticAve };
            
            var propertyGroup = new PropertyGroup("Purple Streets", purpleStreets, new StreetRentCalculator());
            banker.InitializePropertyGroups(new PropertyGroup[] { propertyGroup });

            medAve.LandedOnBy(car);
            balticAve.LandedOnBy(car);
            banker.PayRentToPropertyOwner(horse, balticAve);

            Assert.That(horse.Balance, Is.EqualTo(1992));
            Assert.That(car.Balance, Is.EqualTo(1888));
        }
    }
}
