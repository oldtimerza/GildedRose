using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GildedRose.Console.Models;
using GildedRose.Core.Models.SpecialItems;

namespace GildedRose.Core.Rules
{
    public class SulfurasDegradation : IDegradeRule
    {
        public void Apply(Item item)
        {
            if (item.Name != Sulfuras.SpecialName)
            {
                item.SellIn = item.SellIn - 1;
            }
        }
    }
}
