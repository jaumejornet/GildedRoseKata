namespace GildedRose.Application
{
    public interface IUpdaterStrategy
    {
        void UpdateQuality(Item item);

        void UpdateSellIn(Item item);
    }
}
