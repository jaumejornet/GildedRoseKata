using System;
using System.Linq;

namespace GildedRose
{
    internal class BackstageItemUpdaterStrategy : ItemUpdaterStrategyBase
    {
        private static readonly int[] Limits = { 50, 10, 5 };

        public override void UpdateQuality(Item item)
        {
            if (HasExpired(item))
            {
                item.Quality = 0;
                return;
            }

            var count = Limits.Where(i => item.SellIn <= i).Count();
            IncreaseQuality(item, count);
        }

        private static void IncreaseQuality(Item item, int number)
        {
            item.Quality += number;
            item.Quality = Math.Min(item.Quality, 50);
        }
    }
}