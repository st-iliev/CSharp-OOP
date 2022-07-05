using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> persons = new Dictionary<string, Person>();
            Dictionary<string, Product> products = new Dictionary<string, Product>();
            try
            {
                string[] people = Console.ReadLine().Split(";");
                for (int i = 0; i < people.Length; i++)
                {
                    string[] currentPerson = people[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                    Person newPerson = new Person(currentPerson[0], decimal.Parse(currentPerson[1]));
                    persons.Add(currentPerson[0], newPerson);
                }
                string[] product = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < product.Length; i++)
                {
                    string[] currentProduct = product[i].Split("=");
                    Product newProduct = new Product(currentProduct[0], decimal.Parse(currentProduct[1]));
                    products.Add(currentProduct[0], newProduct);
                }

                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                while (command[0] != "END")
                {
                    string personName = command[0];
                    string productName = command[1];
                    Person person = persons[personName];
                    Product prod = products[productName];
                    bool isBought = person.BuyProduct(prod);
                    if (!isBought)
                    {
                        Console.WriteLine($"{personName} can't afford {prod.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{personName} bought {prod.Name}");
                    }
                    command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            foreach (var item in persons)
            {
                if (item.Value.BagOfProducts.Count == 0)
                {
                    Console.WriteLine($"{item.Key} - Nothing bought");
                }
                else
                {
                    int count = 0;
                    Console.Write($"{item.Key} - ");
                    foreach (var prod in item.Value.BagOfProducts)
                    {
                        count++;
                        if (count == item.Value.BagOfProducts.Count)
                        {
                            Console.WriteLine(prod.Name);
                        }
                        else
                        {
                            Console.Write($"{prod.Name}, ");
                        }
                    }
                }
            }
        }
    }
}
