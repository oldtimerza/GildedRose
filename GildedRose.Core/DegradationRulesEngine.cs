using System.Collections.Generic;
using GildedRose.Core.Rules;

namespace GildedRose.Core
{
    public class DegradationRulesEngine : IRulesEngine
    {
        public IList<IDegradeRule> createRules()
        {
            IList<IDegradeRule> rules = new List<IDegradeRule>()
            {
                new ItemsDegradeBeforeSellBy(),
                new AgedBrieDegradation(),
                new BackstagePassDegradation()
            };
            return rules;
        }
    }
}
