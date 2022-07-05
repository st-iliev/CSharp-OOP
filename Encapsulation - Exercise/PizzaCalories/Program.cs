using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            try
            {
                string[] pizza = Console.ReadLine().Split();
                Pizza newPizza = new Pizza(pizza[1]);
                string[] dough = Console.ReadLine().Split();
                string flourType = dough[1];
                string bakingTechnique = dough[2];
                double weigh = double.Parse(dough[3]);
                Dough newdough = new Dough(flourType, bakingTechnique, weigh);
                newPizza.AddDough(newdough);
                string[] topping = Console.ReadLine().Split();

                while (topping[0] != "END")
                {

                    string type = topping[1];
                    double weighT = double.Parse(topping[2]);
                    Topping topp = new Topping(type, weighT);
                    newPizza.AddToppin(topp);
                    topping = Console.ReadLine().Split();
                }
                Console.WriteLine($"{newPizza.Name} - {newPizza.Calories:F2} Calories.");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return;
            }
        }
    }
}
