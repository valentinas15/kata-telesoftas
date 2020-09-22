using System;

namespace csharp.Rules
{
    /// <summary>
    /// Special item with very specific rules
    /// </summary>
    public class SulfurasRule : IRule
    {
        public void UpdateQuality(Item item)
        {
            // quality never altered
            item.Quality = 80;
        }
    }
}
