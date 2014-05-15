using GildedRose.Application;
using NUnit.Framework;

namespace GildedRose.Tests.Extensions
{
    [TestFixture]
    public class ItemTypeExtenssionsTest
    {
        [TestCase(TestStrings.DefaultItemName, false, TestName = "ItemTypeExtenssionsDefaultItemIsNotSulfuras", Category = TestStrings.ExtensionsCategoryName)]
        [TestCase(TestStrings.SulfurasItemName, true, TestName = "ItemTypeExtenssionsSulfurasBrieItemIsSulfuras", Category = TestStrings.ExtensionsCategoryName)]
        public void SulfurasChecking(string itemName, bool expected)
        {
            var item = new Item { Name = itemName };
            var actual = item.IsSulfuras();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestStrings.DefaultItemName, false, TestName = "ItemTypeExtenssionsDefaultItemIsNotAgedBrie", Category = TestStrings.ExtensionsCategoryName)]
        [TestCase(TestStrings.AgedBrieItemName, true, TestName = "ItemTypeExtenssionsAgedBrieItemIsAgedBrie", Category = TestStrings.ExtensionsCategoryName)]
        public void AgedBrieChecking(string itemName, bool expected)
        {
            var item = new Item { Name = itemName };
            var actual = item.IsAgedBrie();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestStrings.DefaultItemName, false, TestName = "ItemTypeExtenssionsDefaultItemIsNotBackstage", Category = TestStrings.ExtensionsCategoryName)]
        [TestCase(TestStrings.BackstageItemName, true, TestName = "ItemTypeExtenssionsBackstageItemIsBackstage", Category = TestStrings.ExtensionsCategoryName)]
        public void BackstageChecking(string itemName, bool expected)
        {
            var item = new Item { Name = itemName };
            var actual = item.IsBackstage();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestStrings.DefaultItemName, false, TestName = "ItemTypeExtenssionsDefaultItemIsNotConjured", Category = TestStrings.ExtensionsCategoryName)]
        [TestCase(TestStrings.ConjuredItemName, true, TestName = "ItemTypeExtenssionsBackstageItemIsConjured", Category = TestStrings.ExtensionsCategoryName)]
        public void ConjuredChecking(string itemName, bool expected)
        {
            var item = new Item { Name = itemName };
            var actual = item.IsConjured();
            Assert.AreEqual(expected, actual);
        }
    }
}
