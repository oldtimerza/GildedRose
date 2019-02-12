using System;
using GildedRose.Console.Models;

namespace GildedRose.Core.Models.SpecialItems
{
    public class AgedBrie : Item
    {
        public static String SpecialName = "Aged Brie";

        public new String Name { get; private set; }

        public AgedBrie()
        {
            Name = SpecialName;
            base.Name = SpecialName;
        }
    }
}
