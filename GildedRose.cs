using System.Collections.Generic;
using System.Linq;
using GildedRose.Application;

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
            var updater = new UpdaterContext();
            _items.ToList().ForEach(updater.UpdateQuality);
        }
    }
}