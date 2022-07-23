using System;
using Reflection_and_Attributes___Exercise.ValidationAttributes;
namespace ValidationAttributes
{
   public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person
             (
                 "Pesho",
                 15
             );

            bool isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}
