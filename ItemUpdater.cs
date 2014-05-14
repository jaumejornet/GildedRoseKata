namespace GildedRose
{
    internal class ItemUpdater<T> where T : Item
    {
        private static readonly IItemUpdaterStrategy strategy = new DefaultItemUpdaterStrategy();

        public static void UpdateQuality(T item)
        {
            strategy.UpdateQuality(item);
            strategy.UpdateSellIn(item);
        }
    }
}