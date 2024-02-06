using ApprovalUtilities.Utilities;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        public const int maxAmountOfQuality = 50;

        private readonly IList<Item> Items;

        public GildedRose(IList<Item> Items) => this.Items = Items;

        //private static void TryIncreaseQuality(Item item)
        //{
        //    if (item.Quality < maxAmountOfQuality)
        //    {
        //        item.Quality++;
        //    };
        //}

        //private static void TryIncreaseQuality(Item item)
        //{
        //    if (item.Quality < maxAmountOfQuality)
        //    {
        //        item.Quality++;
        //    };
        //}

        private static int CalcualteIncreaseQuality(string name, int sellIn)
        {
            if (name.Equals("Aged Brie"))
            {
                if (sellIn < 0)
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
            else if (name.Equals("Backstage passes to a TAFKAL80ETC concert"))
            {
                if (sellIn < 5)
                {
                    return 3;
                }
                else if (sellIn < 10)
                {
                    return 2;
                }
                else if (sellIn < 0)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else if (name.Equals("Sulfuras, Hand of Ragnaros"))
            {
                return 1;
            }

            return sellIn < 0 ? -2 : -1;
        }

        private static void Update(Item item)
        {
            if (item.Name.Equals("Aged Brie"))
            {
                item.SellIn--;

                if (item.Quality < 50)
                {
                    item.Quality += CalcualteIncreaseQuality(item.Name, item.SellIn);
                }
            }
            else if (item.Name.Equals("Backstage passes to a TAFKAL80ETC concert"))
            {
                item.SellIn--;

                if (item.Quality <= 50)
                {
                    item.Quality += CalcualteIncreaseQuality(item.Name, item.SellIn);

                    if (item.Quality > 50)
                    {
                        item.Quality = 50;
                    }

                    if (item.SellIn < 0)
                    {
                        item.Quality = 0;
                    }
                }
            }
            else if (item.Name.Equals("Sulfuras, Hand of Ragnaros"))
            {
                if (item.Quality < 50)
                {
                    item.Quality += CalcualteIncreaseQuality(item.Name, item.SellIn);
                }
            }
            else
            {
                item.SellIn--;

                if (item.Quality > 0)
                {
                    item.Quality += CalcualteIncreaseQuality(item.Name, item.SellIn);
                    if (item.Quality < 0) item.Quality = 0;
                }
            }
        }

        public void UpdateQuality()
        {
            Items.ForEach(item =>
            {
                Update(item);
            });
        }
    }
}
