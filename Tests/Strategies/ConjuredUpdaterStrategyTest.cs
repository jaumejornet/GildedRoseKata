using GildedRose.Application;
using NUnit.Framework;

namespace GildedRose.Tests.Strategies
{
    [TestFixture]
    public class ConjuredUpdaterStrategyTest : StrategyTestBase<ConjuredUpdaterStrategy>
    {
        [TestCase(5, 4, TestName = "ConjuredUpdaterStrategyDecrementsSellIn", Category = TestStrings.StrategiesCategoryName)]
        public void SellInChanges(int actualSellin, int expectedSellin)
        {
            AssertSellInChange(TestStrings.ConjuredItemName, actualSellin, expectedSellin, 5);
        }

        [TestCase(5, 5, 3, TestName = "ConjuredUpdaterStrategyDecrementsQualityTwice", Category = TestStrings.StrategiesCategoryName)]
        [TestCase(0, 5, 1, TestName = "ConjuredUpdaterStrategyWhenSellinIsZeroDecrementsQualityFourTimes", Category = TestStrings.StrategiesCategoryName)]
        [TestCase(-1, 5, 1, TestName = "ConjuredUpdaterStrategyWhenSellinIsLessThanZeroDecrementsQualityFourTimes", Category = TestStrings.StrategiesCategoryName)]
        public void QualityChanges(int actualSellin, int initialQuality, int expectedQuality)
        {
            AssertQualityChange(TestStrings.ConjuredItemName, actualSellin, initialQuality, expectedQuality);
        }
    }
}
