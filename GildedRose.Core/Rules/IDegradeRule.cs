using GildedRose.Console.Models;

namespace GildedRose.Core.Rules
{
    public interface IDegradeRule
    {
        void Apply(Item item);
    }
}