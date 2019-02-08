using System.Collections.Generic;
using GildedRose.Console.Models;
using GildedRose.Core;

namespace GildedRose.Console
{
    class Program
    {
        private readonly QualityManager _qualityManager;

        public Program()
        {
            _qualityManager = new QualityManager();
        }

        public QualityManager QualityManager
        {
            get { return _qualityManager; }
        }

        static void Main(string[] args)
        {
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

            app.QualityManager.UpdateQuality(Items);

            System.Console.ReadKey();

        }
    }

}
