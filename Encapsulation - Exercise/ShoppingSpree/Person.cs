using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;
        public Person(string name,decimal money)
        {
            Name = name;
            Money = money;
            bagOfProducts = new List<Product>();
        }
        public IReadOnlyCollection<Product> BagOfProducts => bagOfProducts;
        public string Name
        {
            get
            { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }

        }
        public decimal Money
        {
            get
            { return money; }
            private set
            {
                if (value <0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }
        public bool BuyProduct(Product product)
        {
            if (product.Cost <= money)
            {
                money -= product.Cost;
               bagOfProducts.Add(product);
                return true;
            }
            else
            {
                
                return false;
            }
        }
    }
}
