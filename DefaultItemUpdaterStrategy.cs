namespace GildedRose
{
    internal class DefaultItemUpdaterStrategy : ItemUpdaterStrategyBase
    {
        public override void UpdateQuality(Item item)
        {
            DecreaseQuality(item);
            if (HasExpired(item))
            {
                DecreaseQuality(item);    
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
