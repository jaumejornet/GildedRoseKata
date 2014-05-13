using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRose
{
    [TestFixture()]
    public class GildedRoseTest
    {        
        [Test()]
        public void Test_Baja_SellIn()
        {
            const int actualSellin = 5;
            const int expectedSellin = 4;

            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = actualSellin, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(expectedSellin, Items[0].SellIn);
        }

        [TestCase(5, 4)]
        [TestCase(0, 0)]
        public void Test_ItemsQualityShouldDecrease(int initialQ, int expectedQ)
        {

            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 4, Quality = initialQ } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(expectedQ, Items[0].Quality);
        }

        [TestCase(0, 3, 1)]
        public void Test_ItemsQualityShouldDecreaseFaster(int actualS, int initialQ, int expectedQ)
        {

            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = actualS, Quality = initialQ } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(expectedQ, Items[0].Quality);
        }

        [TestCase(0, 3, 2)]
        public void Test_ItemsQualityShouldDecreaseFaster_Negative(int actualS, int initialQ, int expectedQ)
        {

            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = actualS, Quality = initialQ } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreNotEqual(expectedQ, Items[0].Quality);
        }


        [TestCase(1, 2)]
        [TestCase(50, 50)]
        public void Test_ItemsQualityShouldIncrease(int initialQ, int expectedQ)
        {
            int actualS = 1;

            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = actualS, Quality = initialQ } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(expectedQ, Items[0].Quality);
        }

        //“Backstage passes”, like aged brie, increases in Quality as it’s SellIn value approaches; 
        // Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or 
        // less but Quality drops to 0 after the concert 
        
        [TestCase(10, 12, 10)]
        [TestCase(10, 12, 8)]  
        public void Test_BackStageShouldIncreaseQualityByTwoWhenTenOrLessDaysSellIn(int initialQuality, int expectedQuality, int sellIn)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = initialQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(expectedQuality, Items[0].Quality);
        }

        [TestCase(10, 13, 5)]
        [TestCase(10, 13, 3)]
        public void Test_BackStageShouldIncreaseQualityByThreeWhenFiveOrLessDaysSellIn(int initialQuality, int expectedQuality, int sellIn)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = initialQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(expectedQuality, Items[0].Quality);
        }

        [TestCase(10, 0, 0)]
        public void Test_BackStageShouldSetQualityToZeroWhenSellInIsZero(int initialQuality, int expectedQuality, int sellIn)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = initialQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(expectedQuality, Items[0].Quality);
        }

       
        // todo borrar
        //public void Test_ItemsQualityShouldIncreaseWhenSellInIsLessZero(int initialQ, int expectedQ, int sellIn)
        //{
            
        //    IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = sellIn, Quality = initialQ } };
        //    GildedRose app = new GildedRose(Items);
        //    app.UpdateQuality();
        //    Assert.AreEqual(expectedQ, Items[0].Quality);
        //}
 
    }
}

