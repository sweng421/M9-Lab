using System;

namespace M9_Lab.CoffeeMaker
{
    public class CappuccinoProgram : CMM
    {
        public override void RunCoffeeProgram(string str)
        {
            SetLEDNumber(1);
            SetLEDNumber(2);
            base.RunCoffeeProgram(str);
            SetGrindingTime(6);
            SetTemperature(180);
        }
        public override void SetGrindingTime(int secs)
        {
            Console.WriteLine("\n\n**Grinding coffee**");
            Console.WriteLine("Total time: 8 seconds");
        }

        public override void SetLEDNumber(int num)
        {
            base.SetLEDNumber(num);
        }

        public override void SetTemperature(int degrees)
        {
            Console.WriteLine("\nWater temperature: 180 degrees Fahrenheit.");
        }
    }
}
