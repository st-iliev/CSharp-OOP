using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Exeptions
{
    public class FoodExeption : Exception
    {
        public FoodExeption(string message) : base(message)
        {

        }
    }
}
