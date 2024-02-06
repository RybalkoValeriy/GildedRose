using ApprovalUtilities.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csharp
{
    public class Program
    {
        const int DaysInMonth = 31;

        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            var Items = new List<Item>{
                new() {
                    Name = "+5 Dexterity Vest",
                    SellIn = 10,
                    Quality = 20
                },
                new() {
                    Name = "Aged Brie",
                    SellIn = 2,
                    Quality = 0
                },
                new() {
                    Name = "Elixir of the Mongoose",
                    SellIn = 5,
                    Quality = 7
                },
                new() {
                    Name = "Sulfuras, Hand of Ragnaros",
                    SellIn = 0,
                    Quality = 80
                },
                new() {
                    Name = "Sulfuras, Hand of Ragnaros",
                    SellIn = -1,
                    Quality = 80
                },
                new() {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new() {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new() {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
                new() {
                    Name = "Conjured Mana Cake",
                    SellIn = 3,
                    Quality = 6
                }
            };

            var app = new GildedRose(Items);

            var sb = new StringBuilder();

            Enumerable.Range(0, DaysInMonth)
                .ForEach(day =>
                {
                    sb.AppendLine($"-------- day {day} --------");
                    sb.AppendLine("name, sellIn, quality");

                    Items
                     .ForEach(item =>
                     {
                         sb.AppendLine(item.ToString());
                     });

                    if (day != DaysInMonth - 1)
                    {
                        sb.AppendLine("");
                    }
                    app.UpdateQuality();
                });

            Console.WriteLine(sb.ToString());
        }
    }
}
