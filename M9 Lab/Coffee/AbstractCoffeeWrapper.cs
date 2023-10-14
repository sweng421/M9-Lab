namespace M9_Lab.Coffee
{
    public abstract class AbstractCoffeeWrapper : CoffeeIF
    {
        private CoffeeIF wrapee;

        public AbstractCoffeeWrapper(CoffeeIF wrapee)
        {
            this.wrapee = wrapee;
        }

        public CoffeeIF GetCoffee()
        {
            return wrapee;
        }
    }
}
