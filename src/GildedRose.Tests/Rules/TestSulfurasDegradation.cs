using GildedRose.Console.Models;
using GildedRose.Core.Models.SpecialItems;
using GildedRose.Core.Rules;
using NUnit.Framework;

namespace GildedRose.Tests.Rules
{
    [TestFixture]
    public class TestSulfurasDegradation
    {
        private IDegradeRule _rule;

        [SetUp]
        public void Setup()
        {
            _rule = new SulfurasDegradation();
        }

        [Test]
        public void sulfurasShouldNeverDegrade()
        {
            Item sulfuras = new Sulfuras()
            {
                SellIn = 10
            }; 

            _rule.Apply(sulfuras);

            Assert.That(sulfuras.Quality, Is.EqualTo(80));
        }

        [Test]
        public void shouldNotAffectNormalItems()
        {
            int quality = 40;
            Item item = new Item()
            {
                Name = "someItem",
                Quality = quality,
                SellIn = 10
            }; 

            _rule.Apply(item);

            Assert.That(item.Quality, Is.EqualTo(quality));
        }
    }
}
