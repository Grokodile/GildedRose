namespace GildedRose.Console
{
    public class BackstagePassDecorator : ItemDecoratorBase
    {
        public BackstagePassDecorator(Item item)
            : base(item)
        {
        }

        public override void UpdateQuality()
        {
            if (Quality < 50)
            {
                Quality++;

                if (SellIn < 11)
                {
                    if (Quality < 50)
                    {
                        Quality++;
                    }
                }

                if (SellIn < 6)
                {
                    if (Quality < 50)
                    {
                        Quality++;
                    }
                }
            }

            SellIn = SellIn - 1;

            if (SellIn < 0)
            {
                Quality = 0;
            }
        }
    }
}