namespace M9_Lab.CoffeePrograms
{
    public abstract class AbstractCoffeeProgram
    {
        private CMM coffeeMaker;
        public void SetCoffeeMaker(CMM coffeeMaker)
        {
            this.coffeeMaker = coffeeMaker;
        }
        public CMM GetCoffeeMaker()
        {
            return coffeeMaker;
        }
        public abstract void RunCoffeeProgram(string str);
        public abstract void SetGrindingTime(int secs);
        public abstract void SetLEDNumber(int num);
        public abstract void SetTemperature(int degrees);
    }
}
