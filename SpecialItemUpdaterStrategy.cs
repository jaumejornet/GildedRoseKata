namespace GildedRose
{
    internal class SpecialItemUpdaterStrategy : ItemUpdaterStrategyBase
    {
        public override void UpdateQuality(Item item)
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

        private static void IncreaseQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }
        }
    }
}