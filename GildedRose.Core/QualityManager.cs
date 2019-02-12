using System.Collections.Generic;
using GildedRose.Console.Models;
using GildedRose.Core.Rules;

namespace GildedRose.Core
{
    public class QualityManager
    {
        private readonly IList<IDegradeRule> rules;

        public QualityManager(IList<IDegradeRule> rules)
        {
            this.rules = rules;
        }

        public void Update(IList<Item> Items)
        {
            foreach(Item item in Items)
            {
                foreach (IDegradeRule rule in rules)
                {
                    rule.Apply(item);
                }

                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name != "Aged Brie")
                    {
                        if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item.Quality > 0)
                            {
                                if (item.Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    item.Quality = item.Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            item.Quality = item.Quality - item.Quality;
                        }
                    }
                    else
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }
                }
            }
        }
    }
}