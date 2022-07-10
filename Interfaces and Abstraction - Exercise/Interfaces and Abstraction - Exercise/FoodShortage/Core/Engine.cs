using FoodShortage.IO.Interfaces;
using FoodShortage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodShortage.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly List<Citizen> citizen;
        private readonly List<Rebel> rebel;
        public Engine()
        {
            citizen = new List<Citizen>();
            rebel = new List<Rebel>();
        }
        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            int numbers = int.Parse(this.reader.ReadLine());
            for (int i = 0; i < numbers; i++)
            {
                string[] info = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                int age = int.Parse(info[1]);
                if (info.Length == 4)
                {
                    string id = info[2];
                    string birthday = info[3];
                    Citizen newCitizen = new Citizen(name, age, id, birthday);
                    citizen.Add(newCitizen);
                }
                else if (info.Length == 3)
                {
                    string group = info[2];
                    Rebel newRebel = new Rebel(name, age, group);
                    rebel.Add(newRebel);
                }
            }
            string person = this.reader.ReadLine();
            while (person != "End")
            {

                Citizen currentCitizen = citizen.FirstOrDefault(s => s.Name == person);
                Rebel currentRebel = rebel.FirstOrDefault(s => s.Name == person);
                if (currentCitizen != null)
                {
                    currentCitizen.BuyFood();
                }
                if (currentRebel != null)
                {
                    currentRebel.BuyFood();
                }

                person = this.reader.ReadLine();
            }
            int totalFood = 0;
            foreach (var item in citizen.FindAll(s => s.Food > 0))
            {
                totalFood += item.Food;
            }
            foreach (var item in rebel.FindAll(s => s.Food > 0))
            {
                totalFood += item.Food;
            }
            this.writer.WriteLine(totalFood.ToString());
        }
    }
}
