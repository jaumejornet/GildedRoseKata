namespace GildedRose
{
    internal class DefaultItemUpdaterStrategy : IItemUpdaterStrategy
    {
        public void UpdateQuality(Item item)
        {
            DecreaseQuality(item);
            if (HasExpired(item))
            {
                DecreaseQuality(item);    
            }
        }

        public void UpdateSellIn(Item item)
        {
            DecreaseSellIn(item);
        }

        private static bool HasExpired(Item item)
        {
            return item.SellIn <= 0;
        }

        private static void DecreaseSellIn(Item item)
        {
            if (!item.IsSulfuras())
            {
                item.SellIn--;
            }
        }

        private static void DecreaseQuality(Item item)
        {
            if (!HasQuality(item)) return;

            if (!item.IsSulfuras())
            {
                item.Quality--;
            }
        }

        private static bool HasQuality(Item item)
        {
            return item.Quality > 0;
        }
    }
}
