namespace GildedRose
{
    internal class DefaultItemUpdaterStrategy : IItemUpdaterStrategy
    {
        public void UpdateQuality(Item item)
        {
            if (IsExpirable(item))
            {
                DecreaseQuality(item);
                if (!HasExpired(item)) return;
                DecreaseQuality(item);
            }
            else
            {
                IncreaseQuality(item);

                if (item.IsBackstage())
                {
                    if (item.SellIn < 11)
                    {
                        IncreaseQuality(item);
                    }

                    if (item.SellIn < 6)
                    {
                        IncreaseQuality(item);
                    }
                }

                if (!HasExpired(item)) return;


                if (item.IsAgedBrie())
                {
                    IncreaseQuality(item);
                    return;
                }

                if (item.IsBackstage())
                {
                    item.Quality = 0;
                    return;
                }
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

        private static void IncreaseQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }
        }

        private static bool IsExpirable(Item item)
        {
            return (!item.IsAgedBrie() && !item.IsBackstage());
        }
    }
}
