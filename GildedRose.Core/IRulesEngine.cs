using System.Collections.Generic;
using GildedRose.Core.Rules;

namespace GildedRose.Core
{
    public interface IRulesEngine
    {
        IList<IDegradeRule> createRules();
    }
}
