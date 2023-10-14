using System;

namespace M9_Lab.CoffeeMaker
{
    public class MochaProgram : CMM
    {
        public override void RunCoffeeProgram(string str)
        {
            SetLEDNumber(1);
            SetLEDNumber(1);
            base.RunCoffeeProgram(str);
            SetGrindingTime(8);
            SetTemperature(150);
            base.Done();
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
            Console.WriteLine("\nWater temperature: 150 degrees Fahrenheit.");
        }
    }
}
