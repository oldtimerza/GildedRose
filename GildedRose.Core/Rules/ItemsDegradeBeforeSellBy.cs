using GildedRose.Console.Models;
using GildedRose.Core.Models.SpecialItems;

namespace GildedRose.Core.Rules
{
    public class ItemsDegradeBeforeSellBy : IDegradeRule
    {
        public void Apply(Item item)
        {
            if (item.Name != AgedBrie.SpecialName && item.Name != BackstagePass.SpecialName && item.Name != Sulfuras.SpecialName)
            {
                if (item.Quality > 0)
                {
                    if (item.SellIn < 0)
                    {
                        item.Quality = item.Quality - 2;
                    }
                    else
                    {
                        item.Quality = item.Quality - 1;
                    }
                }
            }
        }
    }
}
