using System;
using GildedRose.Console.Models;

namespace GildedRose.Core.Models.SpecialItems
{
    public class Sulfuras : Item
    {
        public static String SpecialName = "Sulfuras, Hand of Ragnaros";

        public new String Name { get; private set; }

        public new int Quality { get; private set; }

        public Sulfuras()
        {
            int quality = 80;
            Name = SpecialName;
            Quality = quality;
            base.Name = SpecialName;
            base.Quality = quality;
        }
    }
}
