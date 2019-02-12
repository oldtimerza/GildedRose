using System.Collections.Generic;
using GildedRose.Console.Models;
using GildedRose.Core;
using GildedRose.Core.Models.SpecialItems;
using GildedRose.Core.Rules;
using SimpleInjector;

namespace GildedRose.Console
{
    class Program
    {
        private static readonly Container container;

        static Program()
        {
            container = new Container();
            container.Register<IRulesSet, DegradationRulesSet>();
            container.Register<QualityAdjuster>();
            container.Register<IItemSet, DefaultItemSet>();
            container.Verify();
        }

        static void Main(string[] args)
        {
            QualityAdjuster qualityAdjuster = container.GetInstance<QualityAdjuster>();
            IItemSet itemSet = container.GetInstance<IItemSet>();

            System.Console.WriteLine("OMGHAI!");

            var app = new Program();

            qualityAdjuster.Update(itemSet.GetItems());

            System.Console.ReadKey();

        }
    }

}
