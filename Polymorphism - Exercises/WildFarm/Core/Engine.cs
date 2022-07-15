using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.IO.Contracts;
using WildFarm.Models;
using WildFarm.Models.Animal;
using WildFarm.Models.Animal.Birds;
using WildFarm.Models.Animal.Mammal;
using WildFarm.Models.Foods;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        public Engine(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }

        public void Run()
        {
            string[] animalInfo = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<Animal> animals = new List<Animal>();
            while (animalInfo[0]!="End")
            {
                string[] currentfood = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string foodType = currentfood[0];
                int quantity = int.Parse(currentfood[1]);
                Food food = null;
               if (foodType == "Vegetable")
                {
                    food = new Vegetable(quantity);
                }
               else if (foodType == "Fruit")
                {
                    food = new Fruit(quantity);
                }
               else if (foodType == "Meat")
                {
                    food = new Meat(quantity);
                }
                else if (foodType == "Seeds")
                {
                    food = new Seeds(quantity);
                }
                string type = animalInfo[0];
                string name = animalInfo[1];
                double weight = double.Parse(animalInfo[2]);
                Animal animal = null;
                if (type == "Owl")
                {
                    double wingSize = double.Parse(animalInfo[3]);
                    animal = new Owl(name,weight,wingSize);
                }
                else if (type == "Hen")
                {
                    double wingSize = double.Parse(animalInfo[3]);
                    animal = new Hen(name, weight, wingSize);
                }
                else if (type == "Mouse")
                {
                    string livingRegion = animalInfo[3];
                    animal = new Mouse(name, weight, livingRegion);
                }
                else if (type == "Dog")
                {
                    string livingRegion = animalInfo[3];
                    animal = new Dog(name, weight, livingRegion);
                }
                else if (type == "Cat")
                {
                    string livingRegion = animalInfo[3];
                    string breed = animalInfo[4];
                    animal = new Cat(name, weight, livingRegion, breed);
                }
                else if (type == "Tiger")
                {
                    string livingRegion = animalInfo[3];
                    string breed = animalInfo[4];
                    animal = new Tiger(name, weight, livingRegion, breed);
                }
               this.writer.WriteLine(animal.ProduceSound());
                try
                {
                animal.Eat(food);
                }
                catch (Exception e)
                {

                    this.writer.WriteLine(e.Message);
                }
                animals.Add(animal);
                animalInfo = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var ani in animals)
            {
                this.writer.WriteLine(ani.ToString());
            }
        }
    }
}
