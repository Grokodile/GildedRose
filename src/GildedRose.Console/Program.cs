using System;
using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public static IList<Item> Items;
        public static void Main(string[] args)
        {
            int updates = 1;
            if (args != null && args.Length >= 1)
            {
                updates = Int32.Parse(args[0]);
            }

            if (args != null && args.Length >= 2 && args[1] == "FeatureType.Conjured == true")
            {
                ItemDecoratorFactory.IsConjuredItemsFeatureEnabled = true;
            }
            else
            {
                ItemDecoratorFactory.IsConjuredItemsFeatureEnabled = false;
            }

            System.Console.WriteLine("OMGHAI!");

            var app = Items = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

                          

            for (int i = 0; i < updates; i++)
            {
                UpdateQuality();
                foreach (var item in Items)
                {
                    System.Console.WriteLine("Name: {0}, SellIn: {1}, Quality: {2}", item.Name, item.SellIn, item.Quality);
                }
            }
        }

        public static void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var adapter = ItemDecoratorFactory.Create(item);
                adapter.UpdateQuality();
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }
}
