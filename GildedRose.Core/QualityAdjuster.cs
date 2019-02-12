using System.Collections.Generic;
using GildedRose.Console.Models;
using GildedRose.Core.Rules;

namespace GildedRose.Core
{
    public class QualityAdjuster
    {
        private readonly IList<IDegradeRule> rules;

        public QualityAdjuster(IList<IDegradeRule> rules)
        {
            this.rules = rules;
        }

        public void Update(IList<Item> Items)
        {
            foreach(Item item in Items)
            {
                foreach (IDegradeRule rule in rules)
                {
                    rule.Apply(item);
                }
            }
        }
    }
}