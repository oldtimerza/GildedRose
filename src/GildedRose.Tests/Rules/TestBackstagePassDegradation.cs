using GildedRose.Console.Models;
using GildedRose.Core.Models.SpecialItems;
using GildedRose.Core.Rules;
using NUnit.Framework;

namespace GildedRose.Tests.Rules
{
    [TestFixture]
    class TestBackstagePassDegradation
    {
        private IDegradeRule _rule;
        private int _quality;

        [SetUp]
        public void Setup()
        {
            _quality = 30;
            _rule = new BackstagePassDegradation(); 
        }

        [Test]
        public void ShouldGetNormalQualityInceaseMoreThan10DaysFromSellBy()
        {
            Item backStagePass = new BackstagePass()
            {
                Quality = _quality,
                SellIn = 20
            };

            _rule.Apply(backStagePass);

            Assert.That(backStagePass.Quality, Is.EqualTo(_quality + 1));
        }

        [Test]
        public void ShouldGetDoubleQualityIncreaseLessThan10DaysFromSellBy()
        {
           Item backStagePass = new BackstagePass()
           {
               Quality =  _quality,
               SellIn = 9 
           };

            _rule.Apply(backStagePass); 
            
            Assert.That(backStagePass.Quality, Is.EqualTo(_quality + 2));
        }

        [Test]
        public void ShouldGetTripleQualityIncreaseLessThan5DaysFromSellBy()
        {
            Item backStagePass = new BackstagePass()
            {
                Quality = _quality,
                SellIn = 4
            };

            _rule.Apply(backStagePass);
            
            Assert.That(backStagePass.Quality, Is.EqualTo(_quality + 3));
        }

        [Test]
        public void ShouldBeWorthlessAfterSellBy()
        {
            Item expiredPass = new BackstagePass()
            {
                Quality = _quality,
                SellIn = -1
            };

            _rule.Apply(expiredPass);

            Assert.That(expiredPass.Quality, Is.EqualTo(0));
        }

        [Test]
        public void ShouldNotAffectNormalItems()
        {
            Item item = new Item()
            {
                Name = "someItem",
                Quality = _quality,
                SellIn = 10
            };

            _rule.Apply(item);

            Assert.That(item.Quality, Is.EqualTo(_quality));
        }
    }
}
