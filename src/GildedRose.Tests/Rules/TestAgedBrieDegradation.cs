using GildedRose.Console.Models;
using GildedRose.Core.Rules;
using NUnit.Framework;

namespace GildedRose.Tests.Rules
{
    [TestFixture]
    class TestAgedBrieDegradation
    {
        private IDegradeRule rule;
        private int quality;

        [SetUp]
        public void setup()
        {
            rule = new AgedBrieDegradation();
            quality = 49;
        }


        [Test]
        public void agedBrieShouldGoUpInQuality()
        {
            Item item = new Item()
            {
                Name = "Aged Brie",
                Quality = quality,
                SellIn = 10
            };
            rule.apply(item);
            Assert.That(item.Quality, Is.EqualTo(quality + 1));
        }

        [Test]
        public void shouldNotApplyToNormalItems()
        {
            Item item = new Item()
            {
                Name = "Not Aged Brie",
                Quality = quality,
                SellIn = 10
            };
            rule.apply(item);
            Assert.That(item.Quality, Is.EqualTo(quality));
        }
    }
}
