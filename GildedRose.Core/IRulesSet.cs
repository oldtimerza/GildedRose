using System.Collections.Generic;
using GildedRose.Core.Rules;

namespace GildedRose.Core
{
    public interface IRulesSet
    {
        IList<IDegradeRule> CreateRules();
    }
}
