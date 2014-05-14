namespace GildedRose
{
    public interface IItemUpdaterStrategy
    {
        void UpdateQuality(Item item);

        void UpdateSellIn(Item item);
    }
}
