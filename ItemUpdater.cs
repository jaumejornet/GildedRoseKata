namespace GildedRose
{
    internal class ItemUpdater<T> where T : Item
    {
        private static bool IsSulfuras(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

        private static bool IsAgedBrie(Item item)
        {
            return item.Name == "Aged Brie";
        }

        private static bool IsBackstage(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private static bool IsExpired(Item item)
        {
            return item.SellIn < 0;
        }

        private static void DecreaseSellIn(Item item)
        {
            if (!IsSulfuras(item))
            {
                item.SellIn--;
            }
        }

        private static void DecreaseQuality(Item item)
        {
            if (!HasQuality(item)) return;

            if (!IsSulfuras(item))
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
            return (!IsAgedBrie(item) && !IsBackstage(item));
        }

        public static void UpdateQuality(T item)
        {
            if (IsExpirable(item))
            {
                DecreaseQuality(item);
            }
            else
            {
                IncreaseQuality(item);

                if (IsBackstage(item))
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
            }

            DecreaseSellIn(item);

            if (!IsExpired(item)) return;

            if (IsExpirable(item))
            {
                DecreaseQuality(item);
                return;
            }

            if (IsAgedBrie(item))
            {
                IncreaseQuality(item);
                return;
            }

            if (IsBackstage(item))
            {
                item.Quality = 0;
                return;
            }
        }

    }
}