using GildedRose.Console.Models;
using GildedRose.Core.Rules;
using NUnit.Framework;

namespace GildedRose.Tests.Rules
{
    [TestFixture]
    class TestItemsDegradeBeforeSellBy
    {
        private int _quality;
        private IDegradeRule _rule;

        [SetUp]
        public void setup()
        {
            _quality = 50;
            _rule = new ItemsDegradeBeforeSellBy();
        }

        [Test]
        public void ShouldDegradeTheQualityBy1()
        {
            Item item = new Item()
            {
                Name = "someItem",
                Quality = _quality,
                SellIn = 10
            };
            _rule.Apply(item);

            Assert.That(item.Quality, Is.EqualTo(_quality - 1));
        }

        [Test]
        public void ShouldDegradeTwiceAsFastAfterSellBy()
        {
            Item item = new Item()
            {
                Name = "someItem",
                Quality = _quality,
                SellIn = -1
            }; 

            _rule.Apply(item);

            Assert.That(item.Quality, Is.EqualTo(_quality - 2));
        }
    }
}
