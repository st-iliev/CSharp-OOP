using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection_and_Attributes___Exercise.ValidationAttributes
{
   public  abstract class MyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object obj);
    }
}
