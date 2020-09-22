using System;
using System.Collections.Generic;

namespace csharp.Rules
{
    public class RuleFactory
    {
        private Dictionary<string, IRule> _rules = new Dictionary<string, IRule>();

        public RuleFactory()
        {
            // Register rules
            RegisterRule(ProductLibrary.PRODUCT_STANDARD, new StandardRule());
            RegisterRule(ProductLibrary.PRODUCT_AGED_BRIE, new AgedBriedRule());
            RegisterRule(ProductLibrary.PRODUCT_SULFURAS, new SulfurasRule());
            RegisterRule(ProductLibrary.PRODUCT_BACKSTAGE_PASSES, new BackstagePassesRule());
        }

        /// <summary>
        /// Get rule processor
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IRule GetProductRule(Item item)
        {
            if (_rules.ContainsKey(item.Name))
            {
                return _rules[item.Name];
            }

            return GetDefaultRule();
        }

        private void RegisterRule(string productName, IRule rule)
        {
            _rules.Add(productName, rule);
        }

        private IRule GetDefaultRule()
        {
            return _rules[ProductLibrary.PRODUCT_STANDARD];
        }
    }
}
