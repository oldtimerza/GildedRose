using GildedRose.Console.Models;

namespace GildedRose.Core.Rules
{
    public interface IDegradeRule
    {
        void apply(Item item);
    }
}