﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection_and_Attributes___Exercise.ValidationAttributes
{
   public  class Person
    {
        private const int minAge = 12;
        private const int maxAge = 90;
        public Person(string fullName , int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }
        [MyRequired]
        public string FullName { get; set; }
        [MyRange(minAge,maxAge)]
        public int Age { get; set; }

    }
}
