using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax.Products
{
    /*
     * These Products are not exempt from regular sales tax
     */
    public class Normal : Product
    {
        public Normal(string name, decimal price, bool isImported, uint quantity)
            : base(name, price, isImported, quantity)
        {
            IsExempt = false;
        }



        public override void CalculateTax()
        {
            decimal taxRate = 0.1m;

            if (IsImported)
                taxRate += 0.05m;

            SalesTax = (Math.Ceiling(Price * taxRate / 0.05m) * 0.05m) * Quantity;

            FinalPrice = (Price * Quantity) + SalesTax;

        }

        public override bool Equals(object? obj)
        {
            return this.Name == ((Normal)obj).Name && this.IsImported == ((Normal)obj).IsImported && this.Price == ((Normal)obj).Price;
        }

        public override int GetHashCode()
        {
            return 48975 * (int)Price;
        }


    }
}
