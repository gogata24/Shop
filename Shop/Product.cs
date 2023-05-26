using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Product
    {
        private string name;
        private double stock;
        private decimal price;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double Stock
        {
            get { return stock; }
            set { stock = value; }
        }
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
        public Product(string name, double stock, decimal price) 
        {
            Name = name;
            Stock = stock;
            Price = price;
        }
    }
}
