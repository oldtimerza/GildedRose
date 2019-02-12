using GildedRose.Console.Models;
using GildedRose.Core.Models.SpecialItems;

namespace GildedRose.Core.Rules
{
    public class BackstagePassDegradation: IDegradeRule
    {
        public void Apply(Item item)
        {
            if (item.Name == BackstagePass.SpecialName)
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

                if (item.SellIn < 0)
                {
                    item.Quality = 0;
                }
            }
        }
    }
}
