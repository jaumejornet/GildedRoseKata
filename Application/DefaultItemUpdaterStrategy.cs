namespace GildedRose.Application
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
            if (HasQuality(item))
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
