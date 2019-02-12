using System.Collections.Generic;
using GildedRose.Console.Models;
using GildedRose.Core;
using GildedRose.Core.Models.SpecialItems;
using GildedRose.Core.Rules;
using SimpleInjector;

namespace GildedRose.Console
{
    class Program
    {
        private static readonly Container container;

        static Program()
        {
            container = new Container();
            IRulesSet rulesSet = new DegradationRulesSet();
            container.RegisterInstance<IList<IDegradeRule>>(rulesSet.CreateRules());
            container.Register<QualityAdjuster>();
            container.Verify();
        }

        static void Main(string[] args)
        {
            QualityAdjuster qualityAdjuster = container.GetInstance<QualityAdjuster>();

            System.Console.WriteLine("OMGHAI!");
            IList<Item> Items = new List<Item>()
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new AgedBrie() {SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Sulfuras() { SellIn = 0},
                new BackstagePass()
                {
                    SellIn = 15,
                    Quality = 20
                },
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            var app = new Program();

            qualityAdjuster.Update(Items);

            System.Console.ReadKey();

        }
    }

}
