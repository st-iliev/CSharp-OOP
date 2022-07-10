using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations.Models
{
    public class Citizen
    {
        private string name;
        private int age;
        private string id;
        private string birthday;

        public Citizen(string name, int age, string id, string birthday)
        {
            this.name = name;
            this.age = age;
            this.id = id;
            this.birthday = birthday;
        }
    }
}
