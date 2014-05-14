using GildedRose.Application;
using NUnit.Framework;

namespace GildedRose.Tests.Strategies
{
    [TestFixture]
    public class EmptyUpdaterStrategyTest : StrategyTestBase<EmptyUpdaterStrategy>
    {
        private const string ItemName = "foo";

        [TestCase(5, 5, TestName = "EmptyUpdaterStrategyDoesNotChangeSellIn")]
        public void SellInChanges(int actualSellin, int expectedSellin)
        {
            AssertSellInChange(ItemName, actualSellin, expectedSellin, 5);
        }

        [TestCase(5, 5, TestName = "EmptyUpdaterStrategyDoesNotChangeQuality")]
        public void QualityChanges(int initialQuality, int expectedQuality)
        {
            AssertQualityChange(ItemName, 5, initialQuality, expectedQuality);
        }
    }
}
