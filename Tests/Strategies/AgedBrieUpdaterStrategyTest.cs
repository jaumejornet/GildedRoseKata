using GildedRose.Application;
using NUnit.Framework;

namespace GildedRose.Tests.Strategies
{
    [TestFixture]
    public class AgedBrieUpdaterStrategyTest : StrategyTestBase<AgedBrieUpdaterStrategy>
    {
        [TestCase(5, 4, TestName = "AgedBrieUpdaterStrategyDecrementsSellIn", Category = TestStrings.StrategiesCategoryName)]
        public void SellInChanges(int actualSellin, int expectedSellin)
        {
            AssertSellInChange(TestStrings.AgedBrieItemName, actualSellin, expectedSellin, 5);
        }

        [TestCase(5, 5, 6, TestName = "AgedBrieUpdaterStrategyIncrementsQuality", Category = TestStrings.StrategiesCategoryName)]
        [TestCase(0, 5, 7, TestName = "AgedBrieUpdaterStrategyWhenSellinIsZeroIncrementsQualityTwice", Category = TestStrings.StrategiesCategoryName)]
        [TestCase(-1, 5, 7, TestName = "AgedBrieUpdaterStrategyWhenSellinIsLessThanZeroIncrementsQualityTwice", Category = TestStrings.StrategiesCategoryName)]
        public void QualityChanges(int actualSellin, int initialQuality, int expectedQuality)
        {
            AssertQualityChange(TestStrings.AgedBrieItemName, actualSellin, initialQuality, expectedQuality);
        }
    }
}
