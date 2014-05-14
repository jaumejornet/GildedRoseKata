using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Application
{
    internal class UpdaterContext
    {
        private static readonly Dictionary<IUpdaterStrategy, Func<Item, bool>> Strategies = CreateStrategies();
       
        public static void UpdateQuality(Item item)
        {
            var strategy = GetStrategy(item);
            strategy.UpdateQuality(item);
            strategy.UpdateSellIn(item);
        }

        private static IUpdaterStrategy GetStrategy(Item item)
        {
            var strategy = Strategies.Where(kp => kp.Value(item)).Select(kp => kp.Key).FirstOrDefault();
            if (strategy == null)
            {
                throw new InvalidOperationException("Strategy not found");
            }

            return strategy;
        }

        private static Dictionary<IUpdaterStrategy, Func<Item, bool>> CreateStrategies()
        {
            return new Dictionary<IUpdaterStrategy, Func<Item, bool>>
                   {
                       {new EmptyUpdaterStrategy(), i => i.IsSulfuras()},
                       {new BackstageUpdaterStrategy(), i => i.IsBackstage()},
                       {new AgedBrieUpdaterStrategy(), i => i.IsAgedBrie()},
                       {new DefaultUpdaterStrategy(), i => true},
                   };
        }
    }
}