using System;

namespace M9_Lab.CoffeePrograms
{
    public class RegularProgram : AbstractCoffeeProgram
    {
        public override void RunCoffeeProgram(string str)
        {
            Console.Write("LED Value: ");
            SetLEDNumber(1);
            SetLEDNumber(0);
            SetGrindingTime(7);
            SetTemperature(150);
            GetCoffeeMaker().Done();
        }
        public override void SetGrindingTime(int secs)
        {
            GetCoffeeMaker().SetGrindingTime(secs);
        }

        public override void SetLEDNumber(int num)
        {
            GetCoffeeMaker().SetLEDNumber(num);
        }

        public override void SetTemperature(int degrees)
        {
            GetCoffeeMaker().SetTemperature(degrees);
        }
    }
}
