namespace GildedRose.Console
{
    public abstract class ItemDecoratorBase
    {
        private readonly Item _item;
        protected ItemDecoratorBase(Item item)
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
}