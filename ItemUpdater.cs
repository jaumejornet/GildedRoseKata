namespace GildedRose
{
    internal class ItemUpdater<T> where T : Item
    {
        private static readonly IItemUpdaterStrategy defaultStrategy = new DefaultItemUpdaterStrategy();
        private static readonly IItemUpdaterStrategy backstageStrategy = new BackstageItemUpdaterStrategy();
        private static readonly IItemUpdaterStrategy agedBrieStrategy = new AgedBrieItemUpdaterStrategy();
        private static readonly IItemUpdaterStrategy emptyStrategy = new EmptyItemUpdaterStrategy();

        public static void UpdateQuality(T item)
        {
            var strategy = GetStrategy(item);
            strategy.UpdateQuality(item);
            strategy.UpdateSellIn(item);
        }

        private static IItemUpdaterStrategy GetStrategy(Item item)
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