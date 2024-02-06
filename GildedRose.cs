using ApprovalUtilities.Utilities;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        public const int maxAmountOfQuality = 50;

        private readonly IList<Item> Items;

        public GildedRose(IList<Item> Items) => this.Items = Items;

        private static int CalculateIncreaseQuality(string name, int sellIn) =>
            name switch
            {
                "Aged Brie" => sellIn < 0 ? 2 : 1,
                "Backstage passes to a TAFKAL80ETC concert" => sellIn switch
                {
                    < 0 => -1,
                    < 5 => 3,
                    < 10 => 2,
                    _ => 1
                },
                "Sulfuras, Hand of Ragnaros" => 1,
                _ => sellIn < 0 ? -2 : -1,
            };

        private static void Update(Item item)
        {
            switch (item.Name)
            {
                case "Sulfuras, Hand of Ragnaros":
                    UpdateSulfuras(item);
                    break;
                case "Aged Brie":
                    UpdateAgedBrie(item);
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    UpdateBackstagePasses(item);
                    break;
                default:
                    UpdateOtherItems(item);
                    break;
            }
        }

        private static void UpdateSulfuras(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality += CalculateIncreaseQuality(item.Name, item.SellIn);
            }
        }

        private static void UpdateAgedBrie(Item item)
        {
            item.SellIn--;
            if (item.Quality < 50)
            {
                item.Quality += CalculateIncreaseQuality(item.Name, item.SellIn);
            }
        }

        private static void UpdateBackstagePasses(Item item)
        {
            item.SellIn--;
            if (item.Quality <= 50)
            {
                item.Quality += CalculateIncreaseQuality(item.Name, item.SellIn);

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

        private static void UpdateOtherItems(Item item)
        {
            item.SellIn--;
            if (item.Quality > 0)
            {
                item.Quality += CalculateIncreaseQuality(item.Name, item.SellIn);
                if (item.Quality < 0)
                {
                    item.Quality = 0;
                };
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
