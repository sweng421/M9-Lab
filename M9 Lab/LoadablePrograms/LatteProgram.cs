using System;

namespace M9_Lab.LoadablePrograms
{
    public class LatteProgram : AbstractLoadableProgram
    {
        public override void RunCoffeeProgram(string str)
        {
            Console.Write("LED Value: ");
            SetLEDNumber(1);
            SetLEDNumber(3);
            SetGrindingTime(6);
            SetTemperature(170);
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
