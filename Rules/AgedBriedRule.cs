using System;

namespace csharp.Rules
{
    public class AgedBriedRule : AbstractRule
    {
        public override void UpdateQuality(Item item)
        {
            UpdateDailySellInValue(item);
            UpdateDailyQualityValue(item, AgingFactor.Positive);
        }
    }
}
