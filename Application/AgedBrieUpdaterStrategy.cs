namespace GildedRose.Application
{
    internal class AgedBrieUpdaterStrategy : UpdaterStrategyBase
    {
        public override void UpdateQuality(Item item)
        {
            item.IncreaseQuality();

            if (HasExpired(item))
            {
                item.IncreaseQuality();
            }
        }
    }
}