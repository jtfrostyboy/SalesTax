using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SalesTax.Products
{
    /*
     * This abstract class represents all the necessary attributes of a project
     */
    public abstract class Product
    {
        public string Name;
        public decimal Price;
        public bool IsImported;
        public bool IsExempt;
        public uint Quantity;
        public decimal SalesTax;
        public decimal FinalPrice;

        public Product(string name, decimal price, bool isImported, uint quantity)
        {
            Name = name;
            Price = price;
            IsImported = isImported;
            Quantity = quantity;
        }

        public abstract void CalculateTax();


    } 
}
