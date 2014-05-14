namespace GildedRose.Application
{
    internal class DefaultUpdaterStrategy : UpdaterStrategyBase
    {
        public override void UpdateQuality(Item item)
        {
            item.DecreaseQuality();
            if (HasExpired(item))
            {
                item.DecreaseQuality();
            }
        }
    }
}
