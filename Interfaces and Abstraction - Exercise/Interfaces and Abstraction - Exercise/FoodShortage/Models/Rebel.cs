﻿using FoodShortage.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Models
{
    public class Rebel : IBuyer
    {
        private int food;
        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Group { get; private set; }
        public int Food { get { return food; } }
        public void BuyFood()
        {
            food += 5;
        }
    }
}
