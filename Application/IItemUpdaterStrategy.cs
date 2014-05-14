namespace GildedRose.Application
{
    public interface IItemUpdaterStrategy
    {
        void UpdateQuality(Item item);

        void UpdateSellIn(Item item);
    }
}
