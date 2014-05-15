namespace GildedRose.Application
{
    public abstract class UpdaterStrategyBase : IUpdaterStrategy
    {
        private const int SellInExpiration = 0;

        public abstract void UpdateQuality(Item item);

        public void UpdateSellIn(Item item)
        {
            DecreaseSellIn(item);
        }

        protected static bool HasExpired(Item item)
        {
            return item.SellIn <= SellInExpiration;
        }

        private static void DecreaseSellIn(Item item)
        {
            item.SellIn--;
        }
    }
}
