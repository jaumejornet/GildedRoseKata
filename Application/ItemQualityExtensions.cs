using System;

namespace GildedRose.Application
{
    internal static class ItemQualityExtensions
    {
        private const int MaxQuality = 50;
        private const int MinQuality = 0;
        public static void SetQuality(this Item item, int quality)
        {
            item.Quality = Math.Max(Math.Min(MaxQuality, quality), MinQuality);
        }

        public static void IncreaseQuality(this Item item, int count = 1)
        {
            item.SetQuality(item.Quality + count);
        }

        public static void DecreaseQuality(this Item item, int count = 1)
        {
            item.SetQuality(item.Quality - count);
        }
    }
}
