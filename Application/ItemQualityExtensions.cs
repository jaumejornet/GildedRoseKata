using System;

namespace GildedRose.Application
{
    internal static class ItemQualityExtensions
    {
        private const int MaxQuality = 50;
        private const int MinQuality = 0;
    
        public static void IncreaseQuality(this Item item, int increment = 1)
        {
            item.Quality = Math.Min(MaxQuality, item.Quality + increment);
        }

        public static void DecreaseQuality(this Item item, int decrement = 1)
        {
            item.Quality = Math.Max(MinQuality, item.Quality - decrement);
        }

        public static void ResetQuality(this Item item)
        {
            item.Quality = MinQuality;
        }
    }
}
