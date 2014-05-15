using GildedRose.Application;
using NUnit.Framework;

namespace GildedRose.Tests.Strategies
{
    [TestFixture]
    public class EmptyUpdaterStrategyTest : StrategyTestBase<EmptyUpdaterStrategy>
    {
        [TestCase(5, 5, TestName = "EmptyUpdaterStrategyDoesNotChangeSellIn", Category = TestStrings.StrategiesCategoryName)]
        public void SellInChanges(int actualSellin, int expectedSellin)
        {
            AssertSellInChange(TestStrings.DefaultItemName, actualSellin, expectedSellin, 5);
        }

        [TestCase(5, 5, TestName = "EmptyUpdaterStrategyDoesNotChangeQuality", Category = TestStrings.StrategiesCategoryName)]
        public void QualityChanges(int initialQuality, int expectedQuality)
        {
            AssertQualityChange(TestStrings.DefaultItemName, 5, initialQuality, expectedQuality);
        }
    }
}
