using System.Collections.Generic;
using GildedRose.Console.Models;
using NUnit.Framework;
using GildedRose.Core;

namespace GildedRose.Tests
{
    [TestFixture]
    class TestQualityManager
    {
        private QualityManager qualityManger;

        private IList<Item> items;

        [SetUp]
        public void setup()
        {
           qualityManger = new QualityManager();
           items = new List<Item>();
        }

        [Test]
        public void itemQualityDegradesEachDayNormallyBeforeSellBy()
        {
            int quality = 10;
            Item item = new Item()
            {
                Name = "Item",
                SellIn = 1,
                Quality = quality
            };
            items.Add(item);

            qualityManger.UpdateQuality(items);

            Assert.That(item.Quality, Is.EqualTo(quality - 1));
        }

        [Test]
        public void itemQualityDegradeTwiceAsFastAfterSellBy()
        {
            int quality = 10;
            Item item = new Item()
            {
                Name = "Item",
                SellIn = -1,
                Quality = quality
            };
            items.Add(item);

            qualityManger.UpdateQuality(items);

            Assert.That(item.Quality, Is.EqualTo(quality - 2));
        }

        [Test]
        public void itemQualityIsNeverNegative()
        {
            int quality = 0;
            Item item = new Item()
            {
                Name = "Item",
                SellIn = -1,
                Quality = quality
            };
            items.Add(item);
            
            qualityManger.UpdateQuality(items);

            Assert.That(item.Quality, Is.GreaterThan(-1));
        }

        [Test]
        public void itemQualityIsNeverMoreThan50()
        {
            int quality = 50;
            Item item = new Item()
            {
                Name = "Item",
                SellIn = 1,
                Quality = quality
            };
            items.Add(item);

            qualityManger.UpdateQuality(items);

            Assert.That(item.Quality, Is.LessThan(51));
        }

        [Test]
        public void agedBrieIncreasesAsItGetsOlderRegardlessOfSellByDate()
        {
            Item brie = new Item()
            {
                Name = "Aged Brie",
                SellIn = -1,
                Quality = 48
            };
            items.Add(brie);

            qualityManger.UpdateQuality(items);

            int expectedQuality = 50;
            Assert.That(brie.Quality, Is.EqualTo(expectedQuality));
        }

        [Test]
        public void sulfurasDisregardsSellByAndNeverDecreasesQuality()
        {
            int quality = 50;
            Item sulfuras = new Item()
            {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = -1,
                Quality = quality
            };
            items.Add(sulfuras);

            qualityManger.UpdateQuality(items);

            Assert.That(sulfuras.Quality, Is.EqualTo(quality));
        }

        [Test]
        public void backStagePassesIncreaseApproachingSellby()
        {
            int quality = 25;
            Item backStagePass = new Item()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 20,
                Quality = quality
            };
            items.Add(backStagePass);

            qualityManger.UpdateQuality(items);

            Assert.That(backStagePass.Quality, Is.EqualTo(quality + 1));
        }

        [Test]
        public void backStagePassesIncreaseTwiceAsFastLessThan10DaysBeforeSale()
        {
            int quality = 25;
            Item backStagePass = new Item()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 9,
                Quality = quality
            };
            items.Add(backStagePass);

            qualityManger.UpdateQuality(items);

            Assert.That(backStagePass.Quality, Is.EqualTo(quality + 2));
        }

        [Test]
        public void backStagePassesIncreaseThreeTimesFasterLessThan5DaysBeforeSale()
        {
            int quality = 25;
            Item backStagePass = new Item()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 4,
                Quality = quality
            };
            items.Add(backStagePass);

            qualityManger.UpdateQuality(items);

            Assert.That(backStagePass.Quality, Is.EqualTo(quality + 3));
        }

        [Test]
        public void backStagePassesAreWorthlessAfterSellby()
        {
            int quality = 25;
            Item backStagePass = new Item()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = -1,
                Quality = quality
            };
            items.Add(backStagePass);

            qualityManger.UpdateQuality(items);

            Assert.That(backStagePass.Quality, Is.EqualTo(0));
        }

    }
}
