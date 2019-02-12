using System.Collections.Generic;
using GildedRose.Console.Models;
using GildedRose.Core.Rules;

namespace GildedRose.Core
{
    public class QualityAdjuster
    {
        private readonly IRulesSet _ruleSet;

        public QualityAdjuster(IRulesSet ruleSet)
        {
            this._ruleSet = ruleSet;
        }

        public void Update(IList<Item> Items)
        {
            foreach(Item item in Items)
            {
                foreach (IDegradeRule rule in _ruleSet.CreateRules())
                {
                    rule.Apply(item);
                }
            }
        }
    }
}