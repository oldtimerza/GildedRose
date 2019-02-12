using System.Collections.Generic;
using GildedRose.Core.Rules;

namespace GildedRose.Core
{
    public class DegradationRulesSet : IRulesSet
    {
        public IList<IDegradeRule> CreateRules()
        {
            IList<IDegradeRule> rules = new List<IDegradeRule>()
            {
                new ItemsDegradeBeforeSellBy(),
                new AgedBrieDegradation(),
                new BackstagePassDegradation(),
                new SulfurasDegradation()
            };
            return rules;
        }
    }
}
