using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.Rules
{
    /// <summary>
    /// Abstract rule
    /// </summary>
    public abstract class AbstractRule : IRule
    {
        protected const int MAX_QUALITY = 50;

        protected const int MIN_QUALITY = 0;

        protected enum AgingFactor : int { Positive = 1, Negative = -1 }

        public abstract void UpdateQuality(Item item);

        /// <summary>
        /// Daily sell in change method
        /// </summary>
        /// <param name="item"></param>
        protected void UpdateDailySellInValue(Item item)
        {
            item.SellIn--;
        }

        /// <summary>
        /// Daily qulaity change method
        /// </summary>
        /// <param name="item"></param>
        /// <param name="change"></param>
        protected void UpdateDailyQualityValue(Item item, AgingFactor change)
        {
            int agingValue = (int)change;

            if (item.SellIn < 0)
            {
                agingValue *= 2;
            }

            item.Quality += agingValue;

            EnforceQualityRange(item);
        }

        /// <summary>
        /// Quality must be within allowed range
        /// </summary>
        /// <param name="item"></param>
        protected void EnforceQualityRange(Item item)
        {
            if (item.Quality >= MAX_QUALITY)
            {
                item.Quality = MAX_QUALITY;
            }

            if (item.Quality <= MIN_QUALITY)
            {
                item.Quality = MIN_QUALITY;
            }
        }
    }
}
