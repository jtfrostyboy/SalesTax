using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax.Products
{
    /*
     * These Products are exempt from regular sales tax
     */
    public class Exempt : Product
    {
        public Exempt(string name, decimal price, bool isImported, uint quantity)
            : base(name, price, isImported, quantity)
        {
            IsExempt = true;
        }
        public override void CalculateTax()
        {
            decimal taxRate = 0.0m;

            if (IsImported)
                taxRate += 0.05m;

            SalesTax = (Math.Ceiling(Price * taxRate / 0.05m) * 0.05m) * Quantity;

            FinalPrice = (Price * Quantity) + SalesTax;
        }

        public override bool Equals(object? obj)
        {
            return this.Name == ((Exempt)obj).Name && this.IsImported == ((Exempt)obj).IsImported && this.Price == ((Exempt)obj).Price;
        }

        public override int GetHashCode()
        {
            return 48975 * (int)Price;
        }

    }
}
