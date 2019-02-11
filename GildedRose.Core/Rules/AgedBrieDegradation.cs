using GildedRose.Console.Models;

namespace GildedRose.Core.Rules
{
    public class AgedBrieDegradation : IDegradeRule
    {
        public void apply(Item item)
        {
            if (item.Name == "Aged Brie")
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }
        }
    }
}
