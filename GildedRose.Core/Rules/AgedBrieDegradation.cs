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
                    item.Quality = item.Quality + 1;
                }
            }
        }
    }
}
