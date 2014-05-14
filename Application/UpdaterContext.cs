namespace GildedRose.Application
{
    internal class UpdaterContext
    {
        private static readonly IUpdaterStrategy defaultStrategy = new DefaultUpdaterStrategy();
        private static readonly IUpdaterStrategy backstageStrategy = new BackstageUpdaterStrategy();
        private static readonly IUpdaterStrategy agedBrieStrategy = new AgedBrieUpdaterStrategy();
        private static readonly IUpdaterStrategy emptyStrategy = new EmptyUpdaterStrategy();

        public static void UpdateQuality(Item item)
        {
            var strategy = GetStrategy(item);
            strategy.UpdateQuality(item);
            strategy.UpdateSellIn(item);
        }

        private static IUpdaterStrategy GetStrategy(Item item)
        {
            if (item.IsSulfuras())
            {
                return emptyStrategy;
            }

            if (item.IsBackstage())
            {
                return backstageStrategy;
            }

            if (item.IsAgedBrie())
            {
                return agedBrieStrategy;
            }

            return defaultStrategy;
        }
    }
}