namespace GildedRose.Application
{
    internal class UpdaterStrategyFactory : IUpdaterStrategyFactory
    {
        public IUpdaterStrategy CreateDefaultStrategy()
        {
            return new DefaultUpdaterStrategy();
        }

        public IUpdaterStrategy CreateEmptyStrategy()
        {
            return new EmptyUpdaterStrategy();
        }
        
        public IUpdaterStrategy CreateAgedBrieStrategy()
        {
            return new AgedBrieUpdaterStrategy();
        }

        public IUpdaterStrategy CreateBackstageStrategy()
        {
            return new BackstageUpdaterStrategy();
        }

        public IUpdaterStrategy CreateConjuredStrategy()
        {
            return new ConjuredUpdaterStrategy();
        }
    }
}
