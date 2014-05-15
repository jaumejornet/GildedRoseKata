using GildedRose.Application;
using NUnit.Framework;

namespace GildedRose.Tests.Strategies
{
    [TestFixture]
    public class UpdaterStrategyFactoryTest
    {
        [TestCase(TestName = "UpdaterStrategyFactoryCreatesDefaultStrategy", Category = TestStrings.StrategiesCategoryName)]
        public void DefaultUpdaterStrategy()
        {
            var factory = new UpdaterStrategyFactory();
            var strategy = factory.CreateDefaultStrategy();
            Assert.AreEqual(typeof(DefaultUpdaterStrategy), strategy.GetType());
        }

        [TestCase(TestName = "UpdaterStrategyFactoryCreatesEmptyStrategy", Category = TestStrings.StrategiesCategoryName)]
        public void EmptyUpdaterStrategy()
        {
            var factory = new UpdaterStrategyFactory();
            var strategy = factory.CreateEmptyStrategy();
            Assert.AreEqual(typeof(EmptyUpdaterStrategy), strategy.GetType());
        }

        [TestCase(TestName = "UpdaterStrategyFactoryCreatesAgedBrieStrategy", Category = TestStrings.StrategiesCategoryName)]
        public void AgedBrieUpdaterStrategy()
        {
            var factory = new UpdaterStrategyFactory();
            var strategy = factory.CreateAgedBrieStrategy();
            Assert.AreEqual(typeof(AgedBrieUpdaterStrategy), strategy.GetType());
        }

        [TestCase(TestName = "UpdaterStrategyFactoryCreatesBackstageStrategy", Category = TestStrings.StrategiesCategoryName)]
        public void BackstageUpdaterStrategy()
        {
            var factory = new UpdaterStrategyFactory();
            var strategy = factory.CreateBackstageStrategy();
            Assert.AreEqual(typeof(BackstageUpdaterStrategy), strategy.GetType());
        }

    }
}
