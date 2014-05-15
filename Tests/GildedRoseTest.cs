using System.Collections.Generic;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class GildedRoseTest
    {
        [TestCase(5, 4, TestName = "SellInShouldDecreased", Category = TestStrings.GeneralCategoryName)]
        public void SellInChanges(int actualSellin, int expectedSellin)
        {
            AssertSellInChange(TestStrings.DefaultItemName, actualSellin, expectedSellin, 5);
        }

        [TestCase(4, 5, 4, TestName = "QualityShouldDecrease", Category = TestStrings.GeneralCategoryName)]
        [TestCase(4, 0, 0, TestName = "QualityShouldNotBeNegative", Category = TestStrings.GeneralCategoryName)]
        [TestCase(0, 3, 1, TestName = "QualityShouldDecreaseFasterWhenSellInIsZero", Category = TestStrings.GeneralCategoryName)]
        public void QualityChanges(int actualSellin, int initialQuality, int expectedQuality)
        {
            AssertQualityChange(TestStrings.DefaultItemName, actualSellin, initialQuality, expectedQuality);
        }

        [TestCase(5, 5, TestName = "SulfurasSellInIsNeverDecreased", Category = TestStrings.GeneralCategoryName)]
        public void SulfurasSellInChanges(int actualSellin, int expectedSellin)
        {
            AssertSellInChange(TestStrings.SulfurasItemName, actualSellin, expectedSellin, 5);
        }

        [TestCase(1, 10, 10, TestName = "SulfurasQualityIsNeverDecreased", Category = TestStrings.GeneralCategoryName)]
        public void SulfurasQualityChanges(int actualSellin, int initialQuality, int expectedQuality)
        {
            AssertQualityChange(TestStrings.SulfurasItemName, actualSellin, initialQuality, expectedQuality);
        }

        [TestCase(1, 1, 2, TestName = "AgedBrieQualityShouldIncrease", Category = TestStrings.GeneralCategoryName)]
        [TestCase(1, 50, 50, TestName = "AgedBrieQualityShouldNotBeGreaterThan50", Category = TestStrings.GeneralCategoryName)]
        public void AgedBrieQualityChanges(int actualSellin, int initialQuality, int expectedQuality)
        {
            AssertQualityChange(TestStrings.AgedBrieItemName, actualSellin, initialQuality, expectedQuality);
        }

        [TestCase(10, 10, 12, TestName = "BackStageShouldIncreaseQualityByTwoWhenTenDaysSellIn", Category = TestStrings.GeneralCategoryName)]
        [TestCase(8, 10, 12, TestName = "BackStageShouldIncreaseQualityByTwoWhenLessThanTenDaysSellIn", Category = TestStrings.GeneralCategoryName)]
        [TestCase(5, 10, 13, TestName = "BackStageShouldIncreaseQualityByThreeWhenFiveDaysSellIn", Category = TestStrings.GeneralCategoryName)]
        [TestCase(3, 10, 13, TestName = "BackStageShouldIncreaseQualityByThreeWhenLessThanFiveDaysSellIn", Category = TestStrings.GeneralCategoryName)]
        [TestCase(0, 10, 0, TestName = "BackStageShouldSetQualityToZeroWhenSellInIsZero", Category = TestStrings.GeneralCategoryName)]
        [TestCase(12, 50, 50, TestName = "BackStageQualityShouldNotBeGreaterThan50", Category = TestStrings.GeneralCategoryName)]
        [TestCase(8, 50, 50, TestName = "BackStageQualityShouldNotBeGreaterThan50EvenWhenLessThanTenDaysSellIn", Category = TestStrings.GeneralCategoryName)]
        [TestCase(3, 50, 50, TestName = "BackStageQualityShouldNotBeGreaterThan50EvenWhenLessThanFiveDaysSellIn", Category = TestStrings.GeneralCategoryName)]
        public void BackstageQualityChanges(int actualSellin, int initialQuality, int expectedQuality)
        {
            AssertQualityChange(TestStrings.BackstageItemName, actualSellin, initialQuality, expectedQuality);
        }

        private static void AssertQualityChange(string itemName, int actualSellin, int initialQuality, int expectedQuality)
        {
            var items = ArangeAndActGildedRose(itemName, actualSellin, initialQuality);
            Assert.AreEqual(expectedQuality, items[0].Quality);
        }

        private static void AssertSellInChange(string itemName, int actualSellin, int expectedSellin, int initialQuality)
        {
            var items = ArangeAndActGildedRose(itemName, actualSellin, initialQuality);
            Assert.AreEqual(expectedSellin, items[0].SellIn);
        }

        private static List<Item> ArangeAndActGildedRose(string itemName, int sellIn, int quality)
        {
            var items = new List<Item> { new Item { Name = itemName, SellIn = sellIn, Quality = quality } };
            var app = new GildedRose(items);
            app.UpdateQuality();

            return items;
        }
    }
}

