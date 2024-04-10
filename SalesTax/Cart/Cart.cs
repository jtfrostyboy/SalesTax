using SalesTax.Products;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax.Cart
{
    public class Cart : ICart
    {
        public Dictionary<Product, uint> Products;
        public Cart(Dictionary<Product, uint> products)
        {
            Products = products;
        }

        /*
         * This method takes in a list of products and creates receipt showing quantity, prices, and taxes to the terminal
         */
        public string CreateReceipt()
        {

            var receipt = "\n";
            decimal totalSalesTaxes = 0;
            decimal totalSalesPrice = 0;


            foreach (Product product in Products.Keys)
            {
                product.Quantity = Products[product];
                if (product.IsImported)
                {
                    product.Name = $"Imported {product.Name}";
                }
                product.CalculateTax();
                totalSalesTaxes += product.SalesTax;
                totalSalesPrice += product.FinalPrice;
                receipt += $"{product.Name}: {product.FinalPrice}" + (product.Quantity > 1 ? $" ({product.Quantity} @ {product.FinalPrice / product.Quantity})\n" : "\n");         
            }

            receipt += $"Sales Taxes: {totalSalesTaxes}\n";
            receipt += $"Total: {totalSalesPrice}";

            return receipt ;
        }

        /*
         * This method takes in a string and prints out the receipt
         */
        public void WriteReceipt(string receipt)
        {
            Console.WriteLine(receipt);
        }

    }

}

