using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GildedRose.Console.Models;

namespace GildedRose.Core.Models.SpecialItems
{
    public class BackstagePass : Item
    {
        public static String SpecialName = "Backstage passes to a TAFKAL80ETC concert";

        public new String Name { get; private set; }

        public BackstagePass()
        {
            Name = SpecialName;
            base.Name = SpecialName;
        }

    }
}
