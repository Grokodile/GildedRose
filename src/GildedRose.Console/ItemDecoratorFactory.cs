namespace GildedRose.Console
{
    public static class ItemDecoratorFactory
    {
        public static bool IsConjuredItemsFeatureEnabled { get; set; }

        public static ItemDecoratorBase Create(Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    return new AgedBrieDecorator(item);
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackstagePassDecorator(item);
                case "Sulfuras, Hand of Ragnaros":
                    return new LegendaryDecorator(item);
                default:
                    if (IsConjuredItemsFeatureEnabled && item.Name.Contains("Conjured"))
                    {
                        return new ConjuredDecorator(item);
                    }
                    return new DefaultDecorator(item);

            }
        }
    }
}