using M9_Lab.Coffee;
using M9_Lab.CoffeePrograms;
using M9_Lab.Condiment;
using M9_Lab.LoadablePrograms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace M9_Lab
{
    public class CMM : ICMM
    {
        IList<CoffeeIF> coffeeIFs = new List<CoffeeIF>();
        AbstractCoffeeProgram coffeeProgram = null;
        AbstractLoadableProgram newProgram = null;

        /*
         * Display menu and let user pick condiments.
         */
        public CMM(String input)
        {
            Console.WriteLine("Available coffee options:");
            Console.WriteLine("\t\t\t0: Regular\n\t\t\t1: Mocha\n\t\t\t2: Cappuccino");
            Console.WriteLine("***Additional programs can be installed via usb***");
            Console.WriteLine("\t\t\t3:Espresso or Latte\n");
            RunCoffeeProgram(input);
        }
        public void ComputePrice()
        {
            Console.WriteLine("\nTotal price: $" + ComputePrice(coffeeIFs.Last()) + "\n");
            Console.WriteLine("**********************************************************");
        }

        /*
         * Using the last coffeeIFs object, recursively call
         * ComputePrice(CoffeeIF cif) with the current object
         * and return the price.
         */
        public double ComputePrice(CoffeeIF cif)
        {
            Type type = cif.GetType();

            if (type == typeof(Regular))
            {
                return 2.0;
            }
            else if (type == typeof(Mocha))
            {
                return 4.0;
            }
            else if (type == typeof(Cappuccino))
            {
                return 3.0;
            }
            else if (type == typeof(Espresso))
            {
                return 5.0;
            }
            else if (type == typeof(Latte))
            {
                return 5.0;
            }
            else
            {
                CoffeeWrapper coffeeWrapper = (CoffeeWrapper)cif;
                Type condimentType = coffeeWrapper.GetCondiment().GetType();

                if (condimentType.Name == "Chocolate")
                {
                    return 1.0 + ComputePrice(coffeeWrapper.GetCoffee());
                }
                else if (condimentType.Name == "Cream")
                {
                    return 0.25 + ComputePrice(coffeeWrapper.GetCoffee());
                }
                else
                    return 0.5 + ComputePrice(coffeeWrapper.GetCoffee());
            }
        }
        public void SetCoffee(CoffeeIF cif)
        {
            coffeeIFs.Add(cif);
        }
        public virtual void RunCoffeeProgram(String str)
        {
            Type type = Type.GetType("M9_Lab.Coffee." + str);
            Type program;

            if (str.Equals("Regular") || str.Equals("Mocha") || str.Equals("Cappuccino"))
                program = Type.GetType("M9_Lab.CoffeePrograms." + str + "Program");
            else    
                program = Type.GetType("M9_Lab.LoadablePrograms." + str + "Program");
            
            if (program.BaseType.Equals(typeof(AbstractCoffeeProgram)))
            {   
                coffeeProgram = (AbstractCoffeeProgram)Activator.CreateInstance(program);
                coffeeProgram.SetCoffeeMaker(this);
                
            }
            else
            {
                newProgram = (AbstractLoadableProgram)Activator.CreateInstance(program);
                newProgram.SetCoffeeMaker(this);
            }

            if (type != null)
            {
                SetCoffee((CoffeeIF)Activator.CreateInstance(type));
            }

            char input;
            Console.Write("Add condiment? (Y/N) ");
            input = Console.ReadKey().KeyChar;

            if (input == 'y' || input == 'Y')
            {
                Console.WriteLine("\nCondiments available:");
                Console.WriteLine("\t\t1: Cream\n\t\t2: Vanilla\n\t\t3: Chocolate");
                int condimentNum = 1;
                do
                {
                    Console.WriteLine("\nEnter condiment " + condimentNum + ":");
                    String condimentType = Console.ReadLine();
                    Type typeOfCondiment = Type.GetType("M9_Lab.Condiment." + condimentType);

                    if (typeOfCondiment != null)
                    {
                        addCondiment((CondimentIF)Activator.CreateInstance(typeOfCondiment));
                    }

                    Console.Write("Add more? (Y/N) ");
                    input = Console.ReadKey().KeyChar;
                    condimentNum++;

                } while (input == 'y' || input == 'Y');

                Console.WriteLine("\n");

                if (coffeeProgram != null)
                    coffeeProgram.RunCoffeeProgram(str);
                else
                    newProgram.RunCoffeeProgram(str);
            }
        }
        public void addCondiment(CondimentIF condiment)
        {
            SetCoffee(new CoffeeWrapper(coffeeIFs.Last(), condiment));
        }
        
        public virtual void SetLEDNumber(int num)
        {
            Console.Write(num);
        }
        public void Done()
        {
            Console.Write("\nCoffee ready!\nLed Value: ");
            SetLEDNumber(0);
            Console.WriteLine("\n");
            ComputePrice();
        }
        public void SetGrindingTime(int secs)
        {
            Console.WriteLine("\n\n**Grinding coffee**");
            Console.WriteLine("Total time: " + secs + " seconds");
        }
        public void SetTemperature(int degrees)
        {
            Console.WriteLine("\nWater temperature: " + degrees + " degrees Fahrenheit.");
        } 
    }
}
