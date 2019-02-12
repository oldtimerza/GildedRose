using System.Collections.Generic;
using GildedRose.Console.Models;

namespace GildedRose.Core
{
    public interface IItemSet
    {
        IList<Item> GetItems();
    }
}
