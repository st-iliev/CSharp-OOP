using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;
        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name
        {
            get 
            { 
                return name; 
            }

            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.Name),"Invalid input!");
                }
                this.name = value;
            }
        }
        public int Age 
        {
            get
            {
                return age;
            }

            set
            {
                if (value<= 0)
                {
                    throw new ArgumentException(nameof(this.Age), "Invalid input!");
                }
                this.age = value;
            }
        }
        public string Gender 
        {
            get
            {
                return gender;
            }

            set
            {
                if (value != "Female" && value != "Male")
                {
                    throw new ArgumentException(nameof(this.Gender), "Invalid input!");
                }
                this.gender = value;
            }
        }
        public abstract string ProduceSound();
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}")
                .AppendLine($"{Name} {Age} {Gender}")
                .AppendLine("{ProduceSound()}");
            return sb.ToString().TrimEnd();
        }
    }
}
