using System;

namespace M9_Lab.LoadablePrograms
{
    public class EspressoProgram : AbstractLoadableProgram
    {
        public override void RunCoffeeProgram(string str)
        {
            Console.Write("LED Value: ");
            SetLEDNumber(1);
            SetLEDNumber(3);
            SetGrindingTime(5);
            SetTemperature(200);
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
