using GildedRose.Console.Models;

namespace GildedRose.Core.Rules
{
    public class ItemsDegradeBeforeSellBy : IDegradeRule
    {
        public void apply(Item item)
        {
            if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (item.Quality > 0)
                {
                    if (item.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        item.Quality = item.Quality - 1;
                    }
                }
            }
        }
    }
}
