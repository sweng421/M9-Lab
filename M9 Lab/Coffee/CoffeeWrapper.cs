using M9_Lab.Condiment;

namespace M9_Lab.Coffee
{
    public class CoffeeWrapper : AbstractCoffeeWrapper
    {
        private CondimentIF condiment;
        public CoffeeWrapper(CoffeeIF wrapee, CondimentIF condiment) : base(wrapee)
        {
            this.condiment = condiment;
        }

        public CondimentIF GetCondiment()
        {
            return condiment;
        }
    }
}
