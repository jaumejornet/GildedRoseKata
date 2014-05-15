using GildedRose.Application;
using NUnit.Framework;

namespace GildedRose.Tests.Strategies
{
    [TestFixture]
    public class BackstageUpdaterStrategyTest : StrategyTestBase<BackstageUpdaterStrategy>
    {
        [TestCase(5, 4, TestName = "BackstageUpdaterStrategyDecrementsSellIn", Category = TestStrings.StrategiesCategoryName)]
        public void SellInChanges(int actualSellin, int expectedSellin)
        {
            AssertSellInChange(TestStrings.BackstageItemName, actualSellin, expectedSellin, 5);
        }

        [TestCase(20, 5, 6, TestName = "BackstageUpdaterStrategyDecrementsQuality", Category = TestStrings.StrategiesCategoryName)]
        [TestCase(10, 5, 7, TestName = "BackstageUpdaterStrategyWhenSellinIsTenDecrementsQualityTwice", Category = TestStrings.StrategiesCategoryName)]
        [TestCase(8, 5, 7, TestName = "BackstageUpdaterStrategyWhenSellinIsLessThanTenDecrementsQualityTwice", Category = TestStrings.StrategiesCategoryName)]
        [TestCase(5, 5, 8, TestName = "BackstageUpdaterStrategyWhenSellinIsFiveDecrementsQualityThreeTimes", Category = TestStrings.StrategiesCategoryName)]
        [TestCase(3, 5, 8, TestName = "BackstageUpdaterStrategyWhenSellinIsLessThanFiveDecrementsQualityThreeTimes", Category = TestStrings.StrategiesCategoryName)]
        [TestCase(0, 5, 0, TestName = "BackstageUpdaterStrategyWhenSellinIsZeroQualityIsZero", Category = TestStrings.StrategiesCategoryName)]
        [TestCase(-1, 5, 0, TestName = "BackstageUpdaterStrategyWhenSellinIsLessThanZeroQualityIsZero", Category = TestStrings.StrategiesCategoryName)]
        public void QualityChanges(int actualSellin, int initialQuality, int expectedQuality)
        {
            AssertQualityChange(TestStrings.BackstageItemName, actualSellin, initialQuality, expectedQuality);
        }
    }
}
