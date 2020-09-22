using System;

namespace csharp.Rules
{
    public class BackstagePassesRule : AbstractRule
    {
        public override void UpdateQuality(Item item)
        {
            if (item.SellIn <= 0)
            {
                // concert date passed
                item.Quality = 0;
            }
            else if (item.SellIn <= 5)
            {
                // ... or less and by 3 when there are 5 days or less but
                item.Quality += 3;                
            } 
            else if (item.SellIn <= 10)
            {
                // lest than 10 days
                item.Quality += 2;
            } 
            else
            {
                item.Quality += 1;
            }

            EnforceQualityRange(item);
            UpdateDailySellInValue(item);
        }

    }
}
