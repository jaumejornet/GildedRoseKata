﻿using System;

namespace GildedRose
{
    internal abstract class ItemUpdaterStrategyBase : IItemUpdaterStrategy
    {
        public abstract void UpdateQuality(Item item);

        public void UpdateSellIn(Item item)
        {
            DecreaseSellIn(item);
        }

        protected static bool HasExpired(Item item)
        {
            return item.SellIn <= 0;
        }

        private static void DecreaseSellIn(Item item)
        {
            item.SellIn--;
        }
    }
}