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

    public abstract class ItemDecorator
    {
        private readonly Item _item;
        protected ItemDecorator(Item item)
        {
            _item = item;
        }

        public abstract void UpdateQuality();

        public string Name
        {
            get { return _item.Name; }
        }

        public int SellIn
        {
            get { return _item.SellIn; }
            set { _item.SellIn = value; }
        }

        public int Quality
        {
            get { return _item.Quality; }
            set { _item.Quality = value; }
        }

        public Item Item { get { return _item; } }
    }

    public class AgedBrieDecorator : ItemDecorator
    {
        private bool isAgedBrie = true;
        private bool isBackstagePass = false;
        private bool isSulfuras = false;

        public AgedBrieDecorator(Item item)
            : base(item)
        {
        }

        public override void UpdateQuality()
        {
            if (isAgedBrie || isBackstagePass || isSulfuras)
            {
                if (Quality < 50)
                {
                    Quality = Quality + 1;

                    if (isBackstagePass)
                    {
                        if (SellIn < 11)
                        {
                            if (Quality < 50)
                            {
                                Quality = Quality + 1;
                            }
                        }

                        if (SellIn < 6)
                        {
                            if (Quality < 50)
                            {
                                Quality = Quality + 1;
                            }
                        }
                    }
                }
            }
            else
            {
                if (Quality > 0)
                {
                    Quality = Quality - 1;
                }
            }

            if (!isSulfuras)
            {
                SellIn = SellIn - 1;
            }

            if (SellIn >= 0) return;

            if (isAgedBrie)
            {
                if (Quality < 50)
                {
                    Quality = Quality + 1;
                }
            }
            else
            {
                if (isBackstagePass)
                {
                    Quality = Quality - Quality;
                }
                else
                {
                    if (Quality > 0 && !isSulfuras)
                    {
                        Quality = Quality - 1;
                    }
                }
            }
        }
    }
    
    public class BackstagePassDecorator : ItemDecorator
    {
        private bool isAgedBrie = false;
        private bool isBackstagePass = true;
        private bool isSulfuras = false;

        public BackstagePassDecorator(Item item)
            : base(item)
        {
        }

        public override void UpdateQuality()
        {
            if (isAgedBrie || isBackstagePass || isSulfuras)
            {
                if (Quality < 50)
                {
                    Quality = Quality + 1;

                    if (isBackstagePass)
                    {
                        if (SellIn < 11)
                        {
                            if (Quality < 50)
                            {
                                Quality = Quality + 1;
                            }
                        }

                        if (SellIn < 6)
                        {
                            if (Quality < 50)
                            {
                                Quality = Quality + 1;
                            }
                        }
                    }
                }
            }
            else
            {
                if (Quality > 0)
                {
                    Quality = Quality - 1;
                }
            }

            if (!isSulfuras)
            {
                SellIn = SellIn - 1;
            }

            if (SellIn >= 0) return;

            if (isAgedBrie)
            {
                if (Quality < 50)
                {
                    Quality = Quality + 1;
                }
            }
            else
            {
                if (isBackstagePass)
                {
                    Quality = Quality - Quality;
                }
                else
                {
                    if (Quality > 0 && !isSulfuras)
                    {
                        Quality = Quality - 1;
                    }
                }
            }
        }
    }
    
    public class SulfurasDecorator : ItemDecorator
    {
        private bool isAgedBrie = true;
        private bool isBackstagePass = false;
        private bool isSulfuras = true;

        public SulfurasDecorator(Item item)
            : base(item)
        {
        }

        public override void UpdateQuality()
        {
            if (isAgedBrie || isBackstagePass || isSulfuras)
            {
                if (Quality < 50)
                {
                    Quality = Quality + 1;

                    if (isBackstagePass)
                    {
                        if (SellIn < 11)
                        {
                            if (Quality < 50)
                            {
                                Quality = Quality + 1;
                            }
                        }

                        if (SellIn < 6)
                        {
                            if (Quality < 50)
                            {
                                Quality = Quality + 1;
                            }
                        }
                    }
                }
            }
            else
            {
                if (Quality > 0)
                {
                    Quality = Quality - 1;
                }
            }

            if (!isSulfuras)
            {
                SellIn = SellIn - 1;
            }

            if (SellIn >= 0) return;

            if (isAgedBrie)
            {
                if (Quality < 50)
                {
                    Quality = Quality + 1;
                }
            }
            else
            {
                if (isBackstagePass)
                {
                    Quality = Quality - Quality;
                }
                else
                {
                    if (Quality > 0 && !isSulfuras)
                    {
                        Quality = Quality - 1;
                    }
                }
            }
        }
    }

    public class DefaultDecorator : ItemDecorator
    {
        private bool isAgedBrie = false;
        private bool isBackstagePass = false;
        private bool isSulfuras = false;

        public DefaultDecorator(Item item) : base(item)
        {
            
        }

        public override void UpdateQuality()
        {
            if (isAgedBrie || isBackstagePass || isSulfuras)
            {
                if (Quality < 50)
                {
                    Quality = Quality + 1;

                    if (isBackstagePass)
                    {
                        if (SellIn < 11)
                        {
                            if (Quality < 50)
                            {
                                Quality = Quality + 1;
                            }
                        }

                        if (SellIn < 6)
                        {
                            if (Quality < 50)
                            {
                                Quality = Quality + 1;
                            }
                        }
                    }
                }
            }
            else
            {
                if (Quality > 0)
                {
                    Quality = Quality - 1;
                }
            }

            if (!isSulfuras)
            {
                SellIn = SellIn - 1;
            }

            if (SellIn >= 0) return;

            if (isAgedBrie)
            {
                if (Quality < 50)
                {
                    Quality = Quality + 1;
                }
            }
            else
            {
                if (isBackstagePass)
                {
                    Quality = Quality - Quality;
                }
                else
                {
                    if (Quality > 0 && !isSulfuras)
                    {
                        Quality = Quality - 1;
                    }
                }
            }
        }
    }

    public static class ItemDecoratorFactory
    {
        public static ItemDecorator Create(Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    return new AgedBrieDecorator(item);
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackstagePassDecorator(item);
                case "Sulfuras, Hand of Ragnaros":
                    return new SulfurasDecorator(item);
                default:
                    return new DefaultDecorator(item);

            }
        }
    }

}
