using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Part
{
    public enum ProductTypes
    {
        Food,
        Technics
    }
    public class Product
    {
        public string ProductName { get; set; }
        public int Cost { get; set; }
        public ProductTypes ProductType { get; set; }
        public string Image { get; set; }

        public override string ToString()
        {
            return ProductName;
        }
    }


}
