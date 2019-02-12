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
            IRulesEngine rulesEngine = new DegradationRulesEngine();
            container.RegisterInstance<IList<IDegradeRule>>(rulesEngine.CreateRules());
            container.Register<QualityManager>();
            container.Verify();
        }

        static void Main(string[] args)
        {
            QualityManager qualityManager = container.GetInstance<QualityManager>();

            System.Console.WriteLine("OMGHAI!");
            IList<Item> Items = new List<Item>()
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            var app = new Program();

            qualityManager.Update(Items);

            System.Console.ReadKey();

        }
    }

}
