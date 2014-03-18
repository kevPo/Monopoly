using System.Collections.Generic;
using Monopoly;
using Monopoly.Locations.Propertys;
using Monopoly.TraditionalMonopoly;
using NUnit.Framework;

namespace MonopolyTests.LocationTests.PropertysTests
{
    [TestFixture]
    public class RailroadTests
    {
        private IPlayer car;
        private IPlayer horse;
        private Property readingRailroad;
        private Property pennsylvaniaRailroad;
        private Property boRailroad;
        private Property shortLineRailroad;

        [SetUp]
        public void SetUp()
        {
            car = new Player("car", 2000);
            horse = new Player("horse", 2000);
            var titleDeeds = new List<TitleDeed>();
            var propertyManager = new PropertyManager();
            var banker = new TraditionalBanker(titleDeeds, propertyManager);

            readingRailroad = new Railroad(5, "Reading Railroad", banker, propertyManager);
            pennsylvaniaRailroad = new Railroad(15, "Pennsylvania Railroad", banker, propertyManager);
            boRailroad = new Railroad(25, "B. & O. Railroad", banker, propertyManager);
            shortLineRailroad = new Railroad(35, "Short Line Railroad", banker, propertyManager);

            titleDeeds.Add(new TitleDeed(readingRailroad, 250, 25, PropertyGroup.Railroad));
            titleDeeds.Add(new TitleDeed(pennsylvaniaRailroad, 250, 25, PropertyGroup.Railroad));
            titleDeeds.Add(new TitleDeed(boRailroad, 250, 25, PropertyGroup.Railroad));
            titleDeeds.Add(new TitleDeed(shortLineRailroad, 250, 25, PropertyGroup.Railroad));
        }

        [Test]
        public void TestRentForOneRailroadOwnerIs25()
        {
            readingRailroad.LandedOnBy(car);
            readingRailroad.LandedOnBy(horse);
            
            Assert.That(horse.Balance, Is.EqualTo(1975));
        }

        [Test]
        public void TestRentForTwoRailRoadOwnerIs50()
        {
            readingRailroad.LandedOnBy(car);
            pennsylvaniaRailroad.LandedOnBy(car);

            pennsylvaniaRailroad.LandedOnBy(horse);
            Assert.That(horse.Balance, Is.EqualTo(1950));
        }

        [Test]
        public void TestRentForThreeRailroadsOwnedIs100()
        {
            readingRailroad.LandedOnBy(car);
            pennsylvaniaRailroad.LandedOnBy(car);
            boRailroad.LandedOnBy(car);

            readingRailroad.LandedOnBy(horse);
            Assert.That(horse.Balance, Is.EqualTo(1900));
        }

        [Test]
        public void TestRentForFourRailroadsOwnedIs200()
        {
            readingRailroad.LandedOnBy(car);
            pennsylvaniaRailroad.LandedOnBy(car);
            boRailroad.LandedOnBy(car);
            shortLineRailroad.LandedOnBy(car);

            readingRailroad.LandedOnBy(horse);
            Assert.That(horse.Balance, Is.EqualTo(1800));
        }
    }
}
