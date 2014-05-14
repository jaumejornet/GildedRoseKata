namespace GildedRose
{
    internal static class ItemTypeExtenssions
    {
        private const string SulfurasItemName = "Sulfuras, Hand of Ragnaros";
        private const string AgedBrieItemName = "Aged Brie";
        private const string BackstageItemName = "Backstage passes to a TAFKAL80ETC concert";

        public static bool IsSulfuras(this Item item)
        {
            return item.Name == SulfurasItemName;
        }

        public static bool IsAgedBrie(this Item item)
        {
            return item.Name == AgedBrieItemName;
        }

        public static bool IsBackstage(this Item item)
        {
            return item.Name == BackstageItemName;
        }
    }
}
