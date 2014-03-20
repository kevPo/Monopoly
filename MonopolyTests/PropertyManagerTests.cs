using System.Collections.Generic;
using Monopoly;
using Monopoly.Locations.Propertys;
using MonopolyTests.Fakes;
using NUnit.Framework;

namespace MonopolyTests
{
    [TestFixture]
    public class PropertyManagerTests
    {
        private Player player;
        private PropertyManager propertyManager;
        private IBanker banker;
        private Railroad readingRailroad;
        private TitleDeed readingDeed;
        private TitleDeed pennsylvaniaDeed;
        private TitleDeed boDeed;
        private TitleDeed shortLineDeed;

        [SetUp]
        public void SetUp()
        {
            player = new Player("Horse", 2000);
            propertyManager = new PropertyManager();
            banker = new FakeBanker();

            readingRailroad = new Railroad(5, "Reading Railroad", banker, propertyManager);
            var pennsylvaniaRailroad = new Railroad(15, "Pennsylvania Railroad", banker, propertyManager);
            var boRailroad = new Railroad(25, "B. & O. Railroad", banker, propertyManager);
            var shortLineRailroad = new Railroad(35, "Short Line Railroad", banker, propertyManager);
            
            readingDeed = new TitleDeed(readingRailroad, 250, 25, PropertyGroup.Railroad);
            pennsylvaniaDeed = new TitleDeed(pennsylvaniaRailroad, 250, 25, PropertyGroup.Railroad);
            boDeed = new TitleDeed(boRailroad, 250, 25, PropertyGroup.Railroad);
            shortLineDeed = new TitleDeed(shortLineRailroad, 250, 25, PropertyGroup.Railroad);
        }

        [Test]
        public void TestPropertyPurchasedMakesPlayerOwnerOfProperty()
        {
            propertyManager.PropertyPurchasedBy(player, readingDeed);
            Assert.That(propertyManager.GetOwnerFor(readingRailroad), Is.EqualTo(player));
        }

        [Test]
        public void TestPropertyIsOwnedReturnsTrue()
        {
            propertyManager.PropertyPurchasedBy(player, readingDeed);
            Assert.That(propertyManager.IsPropertyOwned(readingRailroad), Is.True);
        }

        [Test]
        public void TestPropertyIsOwnedReturnsFalse()
        {
            Assert.That(propertyManager.IsPropertyOwned(readingRailroad), Is.False);
        }

        [Test]
        public void TestNumberOfPropertiesOwnedInGroupWhenAllRailroadsAreBoughtReturnsFour()
        {
            BuyRailroads(player, new TitleDeed[] { readingDeed, pennsylvaniaDeed, boDeed, shortLineDeed });
            Assert.That(propertyManager.GetNumberOfOwnedPropertiesInGroupFor(readingRailroad), Is.EqualTo(4));
        }

        [Test]
        public void TestNumberOfPropertiesOwnedInGroupByOwnerReturnsTwoWhenOwnerOwnsTwo()
        {
            BuyRailroads(player, new TitleDeed[] { readingDeed, pennsylvaniaDeed });
            Assert.That(propertyManager.GetNumberOfOwnedPropertiesInGroupFor(readingRailroad), Is.EqualTo(2));
        }

        private void BuyRailroads(IPlayer buyingPlayer,IEnumerable<TitleDeed> deedsToPurchase)
        {
            foreach (var deed in deedsToPurchase)
                propertyManager.PropertyPurchasedBy(buyingPlayer, deed);
        }

        [Test]
        public void TestNumberOfPropertiesOwnedByOwnerReturnsThreeAndOwnedPropertiesReturnsFour()
        {
            var player2 = new Player("car", 2000);
            BuyRailroads(player, new TitleDeed[] { readingDeed, pennsylvaniaDeed, boDeed });
            BuyRailroads(player2, new TitleDeed[] { shortLineDeed });

            Assert.That(propertyManager.GetNumberOfOwnedPropertiesInGroupFor(readingRailroad), Is.EqualTo(4));
            Assert.That(propertyManager.GetNumberOfOwnedPropertiesInGroupFor(player, readingRailroad), Is.EqualTo(3));
            Assert.That(propertyManager.GetNumberOfOwnedPropertiesInGroupFor(player2, shortLineDeed.Property), Is.EqualTo(1));
        }

        [Test]
        public void TestNumberOfPropertiesInGroupOwnedByPlayerDoesNotIncludeOtherGroups()
        {
            var boardwalk = new Street(39, "Boardwalk", banker, propertyManager);
            var boardwalkDeed = new TitleDeed(boardwalk, 400, 50, PropertyGroup.Blue);
            propertyManager.PropertyPurchasedBy(player, boardwalkDeed);
            BuyRailroads(player, new TitleDeed[] { readingDeed, pennsylvaniaDeed, boDeed });

            Assert.That(propertyManager.GetNumberOfOwnedPropertiesInGroupFor(player, readingRailroad), Is.EqualTo(3));
            Assert.That(propertyManager.GetNumberOfOwnedPropertiesInGroupFor(player, boardwalk), Is.EqualTo(1));
        }
    }
}
