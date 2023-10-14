using System;

namespace M9_Lab.CoffeePrograms
{
    public class CappuccinoProgram : AbstractCoffeeProgram
    {
        public override void RunCoffeeProgram(string str)
        {
            Console.Write("LED Value: ");
            SetLEDNumber(1);
            SetLEDNumber(2);
            SetGrindingTime(6);
            SetTemperature(180);
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
