using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        IList<Item> Items;
        public static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
                          {
                              Items = new List<Item>
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
                                          }

                          };

            for (int i = 0; i < 200; i++)
            {
                app.UpdateQuality();
                foreach (var item in app.Items)
                {
                    System.Console.WriteLine("Name: {0}, SellIn: {1}, Quality: {2}", item.Name, item.SellIn, item.Quality);
                }
            }
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                bool isAgedBrie = item.Name == "Aged Brie";
                bool isBackstagePass = item.Name == "Backstage passes to a TAFKAL80ETC concert";
                bool isSulfuras = item.Name == "Sulfuras, Hand of Ragnaros";

                if (isAgedBrie || isBackstagePass || isSulfuras)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;

                        if (isBackstagePass)
                        {
                            if (item.SellIn < 11)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (item.Quality > 0)
                    {
                        item.Quality = item.Quality - 1;
                    }
                }

                if (!isSulfuras)
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn < 0)
                {
                    if (!isAgedBrie)
                    {
                        if (!isBackstagePass)
                        {
                            if (item.Quality > 0)
                            {
                                if (!isSulfuras)
                                {
                                    item.Quality = item.Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            item.Quality = item.Quality - item.Quality;
                        }
                    }
                    else
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }
                }
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
