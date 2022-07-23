using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection_and_Attributes___Exercise.ValidationAttributes
{
    class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            return obj != null;
        }
    }
}
