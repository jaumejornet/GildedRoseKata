using GildedRose.Application;
using NUnit.Framework;

namespace GildedRose.Tests.Extensions
{
    [TestFixture]
    public class ItemQualityExtensionsTest
    {
        [TestCase(5, 6, TestName = "ItemQualityExtensionsIncreasesByOne", Category = TestStrings.ExtensionsCategoryName)]
        [TestCase(50, 50, TestName = "ItemQualityExtensionsIncreasesByOneCannotBeGreaterThan50", Category = TestStrings.ExtensionsCategoryName)]
        public void Increasing(int actualQuality, int expectedQuality)
        {
            var item = new Item {Quality = actualQuality};
            item.IncreaseQuality();
            Assert.AreEqual(expectedQuality, item.Quality);
        }

        [TestCase(5, 15, 10, TestName = "ItemQualityExtensionsIncreasesByOtherNumber", Category = TestStrings.ExtensionsCategoryName)]
        [TestCase(50, 50, 3, TestName = "ItemQualityExtensionsIncreasesByOtherNumberCannotBeGreaterThan50", Category = TestStrings.ExtensionsCategoryName)]
        public void Increasing(int actualQuality, int expectedQuality, int increment)
        {
            var item = new Item { Quality = actualQuality };
            item.IncreaseQuality(increment);
            Assert.AreEqual(expectedQuality, item.Quality);
        }

        [TestCase(5, 4, TestName = "ItemQualityExtensionsDecreasesByOne", Category = TestStrings.ExtensionsCategoryName)]
        [TestCase(0, 0, TestName = "ItemQualityExtensionsDecreasesByOneCannotBeLessThanZero", Category = TestStrings.ExtensionsCategoryName)]
        public void Decreasing(int actualQuality, int expectedQuality)
        {
            var item = new Item { Quality = actualQuality };
            item.DecreaseQuality();
            Assert.AreEqual(expectedQuality, item.Quality);
        }

        [TestCase(15, 5, 10, TestName = "ItemQualityExtensionsDecreasesByOtherNumber", Category = TestStrings.ExtensionsCategoryName)]
        [TestCase(0, 0, 3, TestName = "ItemQualityExtensionsDecreasesByOtherNumberCannotBeLessThanZero", Category = TestStrings.ExtensionsCategoryName)]
        public void Decreasing(int actualQuality, int expectedQuality, int increment)
        {
            var item = new Item { Quality = actualQuality };
            item.DecreaseQuality(increment);
            Assert.AreEqual(expectedQuality, item.Quality);
        }

        [TestCase(15, 0, TestName = "ItemQualityExtensionsResetToZero", Category = TestStrings.ExtensionsCategoryName)]
        public void Reseting(int actualQuality, int expectedQuality)
        {
            var item = new Item { Quality = actualQuality };
            item.ResetQuality();
            Assert.AreEqual(expectedQuality, item.Quality);
        }
    }
}
