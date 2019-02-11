using GildedRose.Console.Models;

namespace GildedRose.Core.Rules
{
    public class BackstagePassDegradation: IDegradeRule
    {
        public void apply(Item item)
        {
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
                if (item.SellIn < 11)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }

                if (item.SellIn < 6)
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
