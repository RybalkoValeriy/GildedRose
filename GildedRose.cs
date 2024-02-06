using ApprovalUtilities.Utilities;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private readonly IList<Item> Items;

        public GildedRose(IList<Item> Items) => this.Items = Items;

        public void UpdateQuality()
        {
            Items.ForEach(item =>
            {
                if (!item.Name.Equals("Aged Brie") && !item.Name.Equals("Backstage passes to a TAFKAL80ETC concert"))
                {
                    if (item.Quality > 0)
                    {
                        if (!item.Name.Equals("Sulfuras, Hand of Ragnaros"))
                        {
                            item.Quality--;
                        }
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality++;

                        if (item.Name.Equals("Backstage passes to a TAFKAL80ETC concert"))
                        {
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
                    }
                }

                if (!item.Name.Equals("Sulfuras, Hand of Ragnaros"))
                {
                    item.SellIn--;
                }

                if (item.SellIn < 0)
                {
                    if (!item.Name.Equals("Aged Brie"))
                    {
                        if (!item.Name.Equals("Backstage passes to a TAFKAL80ETC concert"))
                        {
                            if (item.Quality > 0)
                            {
                                if (!item.Name.Equals("Sulfuras, Hand of Ragnaros"))
                                {
                                    item.Quality--;
                                }
                            }
                        }
                        else
                        {
                            item.Quality -= item.Quality;
                        }
                    }
                    else
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality++;
                        }
                    }
                }
            });
        }
    }
}
