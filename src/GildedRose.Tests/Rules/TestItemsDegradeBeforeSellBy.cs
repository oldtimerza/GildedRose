using GildedRose.Console.Models;
using GildedRose.Core.Rules;
using NUnit.Framework;

namespace GildedRose.Tests.Rules
{
    [TestFixture]
    class TestItemsDegradeBeforeSellBy
    {
        [Test]
        public void shouldDegradeTheQualityBy1()
        {
            IDegradeRule rule = new ItemsDegradeBeforeSellBy();
            int quality = 50;
            Item item = new Item()
            {
                Name = "someItem",
                Quality = quality,
                SellIn = 10
            };
            rule.apply(item);

            Assert.That(item.Quality, Is.EqualTo(quality - 1));
        }
    }
}
