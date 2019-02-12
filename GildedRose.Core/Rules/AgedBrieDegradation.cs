using GildedRose.Console.Models;
using GildedRose.Core.Models.SpecialItems;

namespace GildedRose.Core.Rules
{
    public class AgedBrieDegradation : IDegradeRule
    {
        public void Apply(Item item)
        {
            if (item.Name == AgedBrie.SpecialName)
            {
                if (item.Quality < 50)
                {
                    if (item.SellIn < 0)
                    {
                        item.Quality = item.Quality + 2;
                    }
                    else
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }
        }
    }
}
