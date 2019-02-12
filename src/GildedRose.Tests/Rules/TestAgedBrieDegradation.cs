using GildedRose.Console.Models;
using GildedRose.Core.Models.SpecialItems;
using GildedRose.Core.Rules;
using NUnit.Framework;

namespace GildedRose.Tests.Rules
{
    [TestFixture]
    class TestAgedBrieDegradation
    {
        private IDegradeRule _rule;
        private int _quality;

        [SetUp]
        public void Setup()
        {
            _rule = new AgedBrieDegradation();
            _quality = 49;
        }


        [Test]
        public void AgedBrieShouldGoUpInQuality()
        {
            Item item = new AgedBrie()
            {
                Quality =  _quality,
                SellIn = 10
            };
            _rule.Apply(item);
            Assert.That(item.Quality, Is.EqualTo(_quality + 1));
        }

        [Test]
        public void AgedBrieShouldGoUpTwiceAsMuchAfterSellBy()
        {
            Item item = new AgedBrie()
            {
                Quality =  _quality,
                SellIn = -1
            };
            _rule.Apply(item);
            Assert.That(item.Quality, Is.EqualTo(_quality + 2));
        }

        [Test]
        public void ShouldNotApplyToNormalItems()
        {
            Item item = new Item()
            {
                Name = "Not Aged Brie",
                Quality = _quality,
                SellIn = 10
            };
            _rule.Apply(item);
            Assert.That(item.Quality, Is.EqualTo(_quality));
        }
    }
}
