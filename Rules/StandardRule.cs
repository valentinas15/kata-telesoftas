using System;

namespace csharp.Rules
{
    public class StandardRule : AbstractRule
    {
        public override void UpdateQuality(Item item)
        {
            UpdateDailySellInValue(item);
            UpdateDailyQualityValue(item, AgingFactor.Negative);
        }
    }
}
