namespace GildedRose
{
    internal class ItemUpdater<T> where T : Item
    {
        private static readonly IItemUpdaterStrategy defaultStrategy = new DefaultItemUpdaterStrategy();
        private static readonly IItemUpdaterStrategy specialStrategy = new SpecialItemUpdaterStrategy();

        public static void UpdateQuality(T item)
        {
            var strategy = GetStrategy(item);
            strategy.UpdateQuality(item);
            strategy.UpdateSellIn(item);
        }

        private static IItemUpdaterStrategy GetStrategy(Item item)
        {
            if (IsExpirable(item))
            {
                return defaultStrategy;
            }

            return specialStrategy;
        }

        private static bool IsExpirable(Item item)
        {
            return (!item.IsAgedBrie() && !item.IsBackstage());
        }
    }
}