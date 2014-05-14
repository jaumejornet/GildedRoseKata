using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRose
{
    [TestFixture]
    public class GildedRoseTest
    {
        private const string DefaultItemName = "foo";
        private const string SulfurasItemName = "Sulfuras, Hand of Ragnaros";
        private const string AgedBrieItemName = "Aged Brie";
        private const string BackstageItemName = "Backstage passes to a TAFKAL80ETC concert";

        [TestCase(5, 4, TestName = "SellInShouldDecreased")]
        public void SellInChanges(int actualSellin, int expectedSellin)
        {
            AssertSellInChange(DefaultItemName, actualSellin, expectedSellin, 5);
        }

        [TestCase(4, 5, 4, TestName = "QualityShouldDecrease")]
        [TestCase(4, 0, 0, TestName = "QualityShouldNotBeNegative")]
        [TestCase(0, 3, 1, TestName = "QualityShouldDecreaseFasterWhenSellInIsZero")]
        public void QualityChanges(int actualSellin, int initialQuality, int expectedQuality)
        {
            AssertQualityChange(DefaultItemName, actualSellin, initialQuality, expectedQuality);
        }

        [TestCase(5, 5, TestName = "SulfurasSellInIsNeverDecreased")]
        public void SulfurasSellInChanges(int actualSellin, int expectedSellin)
        {
            AssertSellInChange(SulfurasItemName, actualSellin, expectedSellin, 5);
        }

        [TestCase(1, 10, 10, TestName = "SulfurasQualityIsNeverDecreased")]
        public void SulfurasQualityChanges(int actualSellin, int initialQuality, int expectedQuality)
        {
            AssertQualityChange(SulfurasItemName, actualSellin, initialQuality, expectedQuality);
        }

        [TestCase(1, 1, 2, TestName = "AgedBrieQualityShouldIncrease")]
        [TestCase(1, 50, 50, TestName = "AgedBrieQualityShouldNotBeGreaterThan50")]
        public void AgedBrieQualityChanges(int actualSellin, int initialQuality, int expectedQuality)
        {
            AssertQualityChange(AgedBrieItemName, actualSellin, initialQuality, expectedQuality);
        }

        [TestCase(10, 10, 12, TestName = "BackStageShouldIncreaseQualityByTwoWhenTenDaysSellIn")]
        [TestCase(8, 10, 12, TestName = "BackStageShouldIncreaseQualityByTwoWhenLessThanTenDaysSellIn")]
        [TestCase(5, 10, 13, TestName = "BackStageShouldIncreaseQualityByThreeWhenFiveDaysSellIn")]
        [TestCase(3, 10, 13, TestName = "BackStageShouldIncreaseQualityByThreeWhenLessThanFiveDaysSellIn")]
        [TestCase(0, 10, 0, TestName = "BackStageShouldSetQualityToZeroWhenSellInIsZero")]
        [TestCase(12, 50, 50, TestName = "BackStageQualityShouldNotBeGreaterThan50")]
        [TestCase(8, 50, 50, TestName = "BackStageQualityShouldNotBeGreaterThan50EvenWhenLessThanTenDaysSellIn")]
        [TestCase(3, 50, 50, TestName = "BackStageQualityShouldNotBeGreaterThan50EvenWhenLessThanFiveDaysSellIn")]
        public void BackstageQualityChanges(int actualSellin, int initialQuality, int expectedQuality)
        {
            AssertQualityChange(BackstageItemName, actualSellin, initialQuality, expectedQuality);
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

        private static List<Item> ArangeAndActGildedRose(string itemName, int actualSellin, int initialQuality)
        {
            var items = new List<Item> { new Item { Name = itemName, SellIn = actualSellin, Quality = initialQuality } };
            var app = new GildedRose(items);
            app.UpdateQuality();

            return items;
        }
    }
}

