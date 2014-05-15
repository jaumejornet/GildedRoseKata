namespace GildedRose.Application
{
    public interface IUpdaterStrategyFactory
    {
        IUpdaterStrategy CreateDefaultStrategy();
        IUpdaterStrategy CreateEmptyStrategy();
        IUpdaterStrategy CreateAgedBrieStrategy();
        IUpdaterStrategy CreateBackstageStrategy();
    }
}