namespace GildedRose.Console
{
    public class DefaultDecorator : ItemDecoratorBase
    {
        public DefaultDecorator(Item item)
            : base(item)
        {
        }

        public override void UpdateQuality()
        {
            if (Quality > 0)
            {
                Quality--;
            }

            SellIn = SellIn - 1;

            if (SellIn >= 0) return;

            if (Quality > 0)
            {
                Quality--;
            }
        }
    }
}