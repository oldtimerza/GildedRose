using System.Collections.Generic;
using GildedRose.Console.Models;
using NUnit.Framework;
using GildedRose.Core;

namespace GildedRose.Tests
{
    [TestFixture]
    class TestQualityManager
    {
        private QualityManager _qualityManger;

        private IRulesEngine _rulesEngine;

        private IList<Item> _items;

        [SetUp]
        public void Setup()
        {
            _rulesEngine = new DegradationRulesEngine();
            _qualityManger = new QualityManager(_rulesEngine.CreateRules());
            _items = new List<Item>();
        }

        [Test]
        public void ItemQualityDegradesEachDayNormallyBeforeSellBy()
        {
            int quality = 10;
            Item item = new Item()
            {
                Name = "Item",
                SellIn = 1,
                Quality = quality
            };
            _items.Add(item);

            _qualityManger.Update(_items);

            Assert.That(item.Quality, Is.EqualTo(quality - 1));
        }

        [Test]
        public void ItemQualityDegradeTwiceAsFastAfterSellBy()
        {
            int quality = 10;
            Item item = new Item()
            {
                Name = "Item",
                SellIn = -1,
                Quality = quality
            };
            _items.Add(item);

            _qualityManger.Update(_items);

            Assert.That(item.Quality, Is.EqualTo(quality - 2));
        }

        [Test]
        public void ItemQualityIsNeverNegative()
        {
            int quality = 0;
            Item item = new Item()
            {
                Name = "Item",
                SellIn = -1,
                Quality = quality
            };
            _items.Add(item);
            
            _qualityManger.Update(_items);

            Assert.That(item.Quality, Is.GreaterThan(-1));
        }

        [Test]
        public void ItemQualityIsNeverMoreThan50()
        {
            int quality = 50;
            Item item = new Item()
            {
                Name = "Item",
                SellIn = 1,
                Quality = quality
            };
            _items.Add(item);

            _qualityManger.Update(_items);

            Assert.That(item.Quality, Is.LessThan(51));
        }

        [Test]
        public void AgedBrieIncreasesAsItGetsOlderRegardlessOfSellByDate()
        {
            Item brie = new Item()
            {
                Name = "Aged Brie",
                SellIn = -1,
                Quality = 48
            };
            _items.Add(brie);

            _qualityManger.Update(_items);

            int expectedQuality = 50;
            Assert.That(brie.Quality, Is.EqualTo(expectedQuality));
        }

        [Test]
        public void SulfurasDisregardsSellByAndNeverDecreasesQuality()
        {
            int quality = 50;
            Item sulfuras = new Item()
            {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = -1,
                Quality = quality
            };
            _items.Add(sulfuras);

            _qualityManger.Update(_items);

            Assert.That(sulfuras.Quality, Is.EqualTo(quality));
        }

        [Test]
        public void BackStagePassesIncreaseApproachingSellby()
        {
            int quality = 25;
            Item backStagePass = new Item()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 20,
                Quality = quality
            };
            _items.Add(backStagePass);

            _qualityManger.Update(_items);

            Assert.That(backStagePass.Quality, Is.EqualTo(quality + 1));
        }

        [Test]
        public void BackStagePassesIncreaseTwiceAsFastLessThan10DaysBeforeSale()
        {
            int quality = 25;
            Item backStagePass = new Item()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 9,
                Quality = quality
            };
            _items.Add(backStagePass);

            _qualityManger.Update(_items);

            Assert.That(backStagePass.Quality, Is.EqualTo(quality + 2));
        }

        [Test]
        public void BackStagePassesIncreaseThreeTimesFasterLessThan5DaysBeforeSale()
        {
            int quality = 25;
            Item backStagePass = new Item()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 4,
                Quality = quality
            };
            _items.Add(backStagePass);

            _qualityManger.Update(_items);

            Assert.That(backStagePass.Quality, Is.EqualTo(quality + 3));
        }

        [Test]
        public void BackStagePassesAreWorthlessAfterSellby()
        {
            int quality = 25;
            Item backStagePass = new Item()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = -1,
                Quality = quality
            };
            _items.Add(backStagePass);

            _qualityManger.Update(_items);

            Assert.That(backStagePass.Quality, Is.EqualTo(0));
        }

    }
}
