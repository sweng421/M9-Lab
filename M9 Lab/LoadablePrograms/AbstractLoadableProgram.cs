namespace M9_Lab.LoadablePrograms
{
    public abstract class AbstractLoadableProgram
    {
        private CMM coffeeMaker;
        public void SetCoffeeMaker(CMM coffeeMaker)
        { 
            this.coffeeMaker = coffeeMaker;
        }

    }
}
