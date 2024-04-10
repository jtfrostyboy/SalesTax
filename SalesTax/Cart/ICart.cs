using SalesTax.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax.Cart
{
    internal interface ICart
    {
        string CreateReceipt();
        void WriteReceipt(string receipt);
    }
}
