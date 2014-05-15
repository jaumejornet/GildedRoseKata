namespace GildedRose.Application
{
    public class ConjuredUpdaterStrategy : DefaultUpdaterStrategy
    {
        public override void UpdateQuality(Item item)
        {
            base.UpdateQuality(item);
            base.UpdateQuality(item);
        }
    }
}
