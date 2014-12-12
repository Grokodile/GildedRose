namespace GildedRose.Console
{
    public class AgedBrieDecorator : ItemDecoratorBase
    {
        public AgedBrieDecorator(Item item)
            : base(item)
        {
        }

        public override void UpdateQuality()
        {
            if (Quality < 50)
            {
                Quality++;
            }

            SellIn = SellIn - 1;

            if (SellIn >= 0) return;

            if (Quality < 50)
            {
                Quality++;
            }
        }
    }
}