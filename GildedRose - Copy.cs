using System.Collections.Generic;
using System.Linq;

namespace GildedRose
{
    internal class GildedRose
    {
        private readonly IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items.Where(IsMutable))
            {
                Degrade(item);

                if (item.Name.Contains( "Conjured"))
                {
                    UpdateQuality(item);

                    if (OutOfDate(item))
                        UpdateQualityWhenOutOfDate(item);
                }
            }
        }

        private void Degrade(Item item)
        {
            UpdateQuality(item);

            DecreaseSellIn(item);

            if (OutOfDate(item))
                UpdateQualityWhenOutOfDate(item);
        }

        private static bool OutOfDate(Item item)
        {
            return item.SellIn < 0;
        }

        private void UpdateQualityWhenOutOfDate(Item item)
        {
            if (item.Name == "Aged Brie")
            {
                increaseQuality(item);
            } else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                item.Quality = 0;
            }
            else
            {
                decreaseQuality(item);
            }
        }

        private static void DecreaseSellIn(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }

        private static bool IsMutable(Item item)
        {
            return item.Name != "Sulfuras, Hand of Ragnaros";
        }

        private void UpdateQuality(Item item)
        {
            if (isPerishable(item))
            {
                decreaseQuality(item);
            }
            else
            {
                increaseQuality(item);
            }
        }

        private bool isPerishable(Item item)
        {
            return (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert");
        }

        private void decreaseQuality(Item item)
        {
            if (item.Quality > 0)
                item.Quality = item.Quality - 1;
        }

        private void increaseQuality(Item item)
        {
                incrementQuality(item);

            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                if (item.SellIn < 11)
                {
                    incrementQuality(item);
                }

                if (item.SellIn < 6)
                {
                    incrementQuality(item);
                }
            }
        }

        private void incrementQuality(Item item)
        {
            if (item.Quality < 50)
                item.Quality = item.Quality + 1;
        }
    }



    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }
}