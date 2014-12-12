namespace GildedRose.Console
{
    public class ConjuredDecorator : ItemDecoratorBase
    {
        public ConjuredDecorator(Item item)
            : base(item)
        {
        }

        public override void UpdateQuality()
        {
            if (Quality > 0)
            {
                Quality -= 2;
            }

            SellIn = SellIn - 1;

            if (SellIn >= 0) return;

            if (Quality > 0)
            {
                Quality -= 2;
            }
        }
    }
}