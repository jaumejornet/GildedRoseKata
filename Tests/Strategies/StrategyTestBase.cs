using GildedRose.Application;
using NUnit.Framework;

namespace GildedRose.Tests.Strategies
{
    public abstract class StrategyTestBase<T> where T: IUpdaterStrategy, new()
    {
        protected static void AssertQualityChange(string itemName, int actualSellin, int initialQuality, int expectedQuality)
        {
            var item = CreateItem(itemName, actualSellin, initialQuality);
            var strategy = new T();
            strategy.UpdateQuality(item);
            Assert.AreEqual(expectedQuality, item.Quality);
        }

        protected static void AssertSellInChange(string itemName, int actualSellin, int expectedSellin, int initialQuality)
        {
            var item = CreateItem(itemName, actualSellin, initialQuality);
            var strategy = new T();
            strategy.UpdateSellIn(item);
            Assert.AreEqual(expectedSellin, item.SellIn);
        }

        protected static Item CreateItem(string itemName, int sellIn, int quality)
        {
            return new Item { Name = itemName, SellIn = sellIn, Quality = quality };
        }
    }
}
