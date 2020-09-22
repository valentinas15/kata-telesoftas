using System.Collections.Generic;
using csharp.Rules;

namespace csharp
{
    public class GildedRose
    {
        private IList<Item> _items;

        private RuleFactory _ruleFactory;

        public GildedRose(IList<Item> items)
        {
            _items = items;
            _ruleFactory = new RuleFactory();
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                _ruleFactory.GetProductRule(item).UpdateQuality(item);
            }
        }
    }
}
