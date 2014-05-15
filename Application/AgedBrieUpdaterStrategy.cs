namespace GildedRose.Application
{
    public class AgedBrieUpdaterStrategy : UpdaterStrategyBase
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