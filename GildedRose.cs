using ApprovalUtilities.Utilities;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private readonly IList<Item> Items;

        public GildedRose(IList<Item> Items) => this.Items = Items;

        private static void Update(Item item)
        {
            if (item.Name.Equals("Aged Brie"))
            {
                if (item.Quality < 50)
                {
                    item.Quality++;
                }

                item.SellIn--;

                if (item.SellIn < 0 && item.Quality < 50)
                {
                    item.Quality++;
                }
            }
            else if (item.Name.Equals("Backstage passes to a TAFKAL80ETC concert"))
            {
                if (item.Quality < 50)
                {
                    item.Quality++;
                    if (item.SellIn < 11)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality++;
                        }
                    }

                    if (item.SellIn < 6)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality++;
                        }
                    }
                }

                item.SellIn--;

                if (item.SellIn < 0)
                {
                    item.Quality -= item.Quality;
                }
            }
            else if (item.Name.Equals("Sulfuras, Hand of Ragnaros"))
            {
                if (item.Quality < 50)
                {
                    item.Quality++;
                }
            }
            else
            {
                if (item.Quality > 0)
                {
                    item.Quality--;
                }
                else if (item.Quality < 50)
                {

                    item.Quality++;

                }

                item.SellIn--;

                if (item.SellIn < 0 && item.Quality > 0)
                {

                    item.Quality--;
                }
            }
        }

        public void UpdateQuality()
        {
            Items.ForEach(item =>
            {
                Update(item);
            }
            );
        }
    }
}
