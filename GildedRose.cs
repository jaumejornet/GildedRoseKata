using System.Collections.Generic;
using System.Linq;

namespace GildedRose
{
    internal class GildedRose
    {
        private readonly IList<Item> _items;

        public GildedRose(IList<Item> items)
        {
            _items = items;
        }


        public void UpdateQuality()
        {
            _items.ToList().ForEach(ItemUpdater<Item>.UpdateQuality);
        }
    }
}