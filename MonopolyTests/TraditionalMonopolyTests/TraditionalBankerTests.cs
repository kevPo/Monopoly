using System.Collections.Generic;
using Monopoly;
using Monopoly.Locations.Propertys;
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
        private Property readingRailroad;
        private IPropertyManager propertyManager;

        [SetUp]
        public void SetUp()
        {
            propertyManager = new PropertyManager();
            var titleDeeds = new List<TitleDeed>();
            banker = new TraditionalBanker(titleDeeds, propertyManager);
            car = new Player("car", 2000);
            horse = new Player("horse", 2000);

            readingRailroad = new Railroad(5, "Reading Railroad", banker, propertyManager);
            var pennsylvaniaRailroad = new Railroad(15, "Pennsylvania Railroad", banker, propertyManager);
            var boRailroad = new Railroad(25, "B. & O. Railroad", banker, propertyManager);
            var shortLineRailroad = new Railroad(35, "Short Line Railroad", banker, propertyManager);

            titleDeeds.Add(new TitleDeed(readingRailroad, 250, 25, PropertyGroup.Railroad));
            titleDeeds.Add(new TitleDeed(pennsylvaniaRailroad, 250, 25, PropertyGroup.Railroad));
            titleDeeds.Add(new TitleDeed(boRailroad, 250, 25, PropertyGroup.Railroad));
            titleDeeds.Add(new TitleDeed(shortLineRailroad, 250, 25, PropertyGroup.Railroad));
        }

        [Test]
        public void TestPropertyPurchasedByPlayerRemovesMoneyFromPlayer()
        {
            banker.PropertyPurchasedBy(car, readingRailroad);
            Assert.That(car.Balance, Is.EqualTo(1750));
        }

        [Test]
        public void TestTransferMoney()
        {
            banker.TransferMoney(car, horse, 50);

            Assert.That(car.Balance, Is.EqualTo(1950));
            Assert.That(horse.Balance, Is.EqualTo(2050));
        }

        [Test]
        public void TestGetRentForReadingRailroadReturns25()
        {
            var rent = banker.GetRentFor(readingRailroad);
            Assert.That(rent, Is.EqualTo(25));
        }

        [Test]
        public void TestPlayerCanAffordPropertyReturnsTrue()
        {
            Assert.That(banker.PlayerCanAffordProperty(car, readingRailroad), Is.True);
        }

        [Test]
        public void TestPlayerCanAffordPropertyReturnsFalse()
        {
            var dog = new Player("dog", 0);
            Assert.That(banker.PlayerCanAffordProperty(dog, readingRailroad), Is.False);
        }

        [Test]
        public void TestNumberOfPropertiesInGroupForReturns4ForRailroads()
        {
            Assert.That(banker.NumberOfPropertiesInGroupFor(readingRailroad), Is.EqualTo(4));
        }
    }
}
