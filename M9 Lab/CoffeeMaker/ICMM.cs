using M9_Lab.Coffee;
using M9_Lab.Condiment;
using System;

namespace M9_Lab
{
    public interface ICMM
    {
        void RunCoffeeProgram(String str);
        void SetGrindingTime(int secs);
        void SetTemperature(int degrees);
        void SetLEDNumber(int num);
        void SetCoffee(CoffeeIF cif);
        void ComputePrice();
        void addCondiment(CondimentIF condiment);
    }
}
