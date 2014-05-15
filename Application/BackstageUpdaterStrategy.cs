using System;
using System.Linq;

namespace GildedRose.Application
{
    public class BackstageUpdaterStrategy : UpdaterStrategyBase
    {
        private static readonly int[] IncreasingLimits = { 50, 10, 5 };

        public override void UpdateQuality(Item item)
        {
            if (HasExpired(item))
            {
                item.ResetQuality();
                return;
            }

            var count = GetIncreaseCount(item);
            item.IncreaseQuality(count);
        }

        private static int GetIncreaseCount(Item item)
        {
            return IncreasingLimits.Where(i => item.SellIn <= i).Count();
        }
    }
}