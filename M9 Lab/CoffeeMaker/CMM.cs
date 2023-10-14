using M9_Lab.Coffee;
using M9_Lab.Condiment;
using System;
using System.Collections.Generic;
using System.Linq;

namespace M9_Lab
{
    public abstract class CMM : ICMM
    {
        IList<CoffeeIF> coffeeIFs = new List<CoffeeIF>();
        List<int> ledVals = new List<int>();

        /*
         * Run the program with as little input
         * from user to begin with.
         * Display menu and let user coffee
         * and condiments.
         */
        public CMM()
        {
            String coffeeInput;
            Console.WriteLine("Available coffee options:");
            Console.WriteLine("\t\t\t1: Regular\n\t\t\t2: Mocha\n\t\t\t3: Cappuccino");
            Console.WriteLine("\n***Additional programs can be installed via usb***\n");
            coffeeInput = Console.ReadLine();
            RunCoffeeProgram(coffeeInput);
        }
        public void ComputePrice()
        {
            Console.WriteLine("\nTotal price: $" + ComputePrice(coffeeIFs.Last()) + "\n");
        }

        /*
         * Using the last coffeeIFs object, recursively call
         * ComputePrice(CoffeeIF cif) with the current object
         * and return the price.
         */
        public double ComputePrice(CoffeeIF cif)
        {
            String var = cif.ToString();
            Type type = cif.GetType();

            /*
            if (type == null)
            {
                foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
                {
                    type = asm.GetType(coffeeIFs.ElementAt(length).ToString());
                }
            }
            */

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
            CoffeeIF coffee = null;

            if (type != null)
            {
                coffee = (CoffeeIF)Activator.CreateInstance(type);
                if (coffee != null)
                {
                    SetCoffee(coffee);
                }
            }
            /*
            else
            {
                foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
                {
                    type = asm.GetType(str);
                    if (type != null)
                    {
                        break;
                    }
                }
                coffee = (CoffeeIF)Activator.CreateInstance(type);

                if (coffee != null)
                {
                    SetCoffee(coffee);
                    Console.WriteLine(coffee + " has been added to list");
                }
            }
            */

            int index = 0;
            int iteration = ledVals.Count - 2;

            foreach (int vals in ledVals)
            {
                if (index == iteration)
                    Console.Write("\nCoffee Maker LED Value: " + vals + ": ");
                else if (index == iteration + 1)
                    Console.WriteLine(vals + "\n\n");

                index++;
            }

            char input;
            Console.WriteLine("Add condiment? (Y/N)");
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
                    CondimentIF condiment = null;

                    if (typeOfCondiment != null)
                    {
                        condiment = (CondimentIF)Activator.CreateInstance(typeOfCondiment);
                        if (condiment != null)
                        {
                            addCondiment(condiment);
                        }
                    }
                    /*
                    else
                    {
                        foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
                        {
                            typeOfCondiment = asm.GetType(condimentType);
                            if (typeOfCondiment != null)
                                condiment = (CondimentIF)Activator.CreateInstance(typeOfCondiment);
                        }
                    }
                    */
                    Console.WriteLine("Add more? (Y/N)");
                    input = Console.ReadKey().KeyChar;
                    condimentNum++;
                } while (input == 'y' || input == 'Y');
            }

        }
        public void addCondiment(CondimentIF condiment)
        {
            SetCoffee(new CoffeeWrapper(coffeeIFs.Last(), condiment));
        }
        
        public virtual void SetLEDNumber(int num)
        {
            ledVals.Add(num);
        }
        public void Done()
        {
            ComputePrice();
        }
        public abstract void SetGrindingTime(int secs);
        public abstract void SetTemperature(int degrees);
        

       
    }
}
