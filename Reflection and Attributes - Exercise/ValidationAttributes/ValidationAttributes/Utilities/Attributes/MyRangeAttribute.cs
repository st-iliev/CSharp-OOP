using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection_and_Attributes___Exercise.ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;
        public MyRangeAttribute(int minValue,int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }
        public override bool IsValid(object obj)
        {
            if (obj is int val)
            {
                return val >= this.minValue && val <= this.maxValue;
            }
            return false;
        }
    }
}
