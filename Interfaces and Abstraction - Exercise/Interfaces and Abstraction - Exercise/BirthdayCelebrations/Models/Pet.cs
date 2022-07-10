using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations.Models
{
    public class Pet
    {
        private string name;
        private string birthday;

        public Pet(string name, string birthday)
        {
            this.name = name;
            this.birthday = birthday;
        }
    }
}
