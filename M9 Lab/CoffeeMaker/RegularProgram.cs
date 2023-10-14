using System;

namespace M9_Lab.CoffeeMaker
{
    public class RegularProgram : CMM
    {
        public override void RunCoffeeProgram(string str)
        {
            SetLEDNumber(1);
            SetLEDNumber(0);
            base.RunCoffeeProgram(str);
            SetGrindingTime(7);
            SetTemperature(150);
        }
        public override void SetGrindingTime(int secs)
        {
            Console.WriteLine("\n\n**Grinding coffee**");
            Console.WriteLine("Total time: 7 seconds");
        }

        public override void SetLEDNumber(int num)
        {
            base.SetLEDNumber(num);
        }

        public override void SetTemperature(int degrees)
        {
            Console.WriteLine("\nWater temperature: 150 degrees Fahrenheit.");
        }
    }
}
