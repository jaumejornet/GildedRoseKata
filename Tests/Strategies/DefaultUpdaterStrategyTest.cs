using GildedRose.Application;
using NUnit.Framework;

namespace GildedRose.Tests.Strategies
{
    [TestFixture]
    public class DefaultUpdaterStrategyTest : StrategyTestBase<DefaultUpdaterStrategy>
    {
        [TestCase(5, 4, TestName = "DefaultUpdaterStrategyDecrementsSellIn", Category = TestStrings.StrategiesCategoryName)]
        public void SellInChanges(int actualSellin, int expectedSellin)
        {
            AssertSellInChange(TestStrings.DefaultItemName, actualSellin, expectedSellin, 5);
        }

        [TestCase(5, 5, 4, TestName = "DefaultUpdaterStrategyDecrementsQuality", Category = TestStrings.StrategiesCategoryName)]
        [TestCase(0, 5, 3, TestName = "DefaultUpdaterStrategyWhenSellinIsZeroDecrementsQualityTwice", Category = TestStrings.StrategiesCategoryName)]
        [TestCase(-1, 5, 3, TestName = "DefaultUpdaterStrategyWhenSellinIsLessThanZeroDecrementsQualityTwice", Category = TestStrings.StrategiesCategoryName)]
        public void QualityChanges(int actualSellin, int initialQuality, int expectedQuality)
        {
            AssertQualityChange(TestStrings.DefaultItemName, actualSellin, initialQuality, expectedQuality);
        }
    }
}
