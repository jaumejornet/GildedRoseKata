using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Application
{
    internal class UpdaterContext
    {
        private readonly Dictionary<Func<Item, bool>, IUpdaterStrategy> strategies;
        private readonly IUpdaterStrategyFactory factory;

        public UpdaterContext() : this(new UpdaterStrategyFactory())
        {
        }

        public UpdaterContext(IUpdaterStrategyFactory factory)
        {
            this.factory = factory;
            this.strategies = this.CreateStrategies();
        }

        public void UpdateQuality(Item item)
        {
            var strategy = GetStrategy(item);
            strategy.UpdateQuality(item);
            strategy.UpdateSellIn(item);
        }

        internal IUpdaterStrategy GetStrategy(Item item)
        {
            return this.strategies.Where(kp => kp.Key(item)).Select(kp => kp.Value).FirstOrDefault();
        }

        private Dictionary<Func<Item, bool>, IUpdaterStrategy> CreateStrategies()
        {
            return new Dictionary<Func<Item, bool>, IUpdaterStrategy>
                   {
                       {i => i.IsSulfuras(), this.factory.CreateEmptyStrategy()},
                       {i => i.IsBackstage(), this.factory.CreateBackstageStrategy()},
                       {i => i.IsAgedBrie(), this.factory.CreateAgedBrieStrategy()},
                       { i => true, this.factory.CreateDefaultStrategy()},
                   };
        }
    }
}