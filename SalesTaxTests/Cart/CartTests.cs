using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesTax.Cart;
using SalesTax.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax.Cart.Tests
{
    [TestClass()]
    public class CartTests
    {
        [TestMethod()]
        public void CartTest()
        {
            
        }

        [TestMethod()]
        public void CreateReceiptTest_SingleProduct()
        {
            Product product = new Exempt("Book", (decimal)12.49, false, 1);
            Dictionary<Product, uint> products = new Dictionary<Product, uint> { { product, 1 } };
            Cart cart = new Cart(products);

            string receipt = cart.CreateReceipt();
            string expectedReceipt = "\nBook: 12.49\nSales Taxes: 0.00\nTotal: 12.49";
            Assert.AreEqual(expectedReceipt, receipt);
        }

        [TestMethod()]
        public void CreateReceiptTest_MultipleDifferentProducts()
        {
            Product product1 = new Exempt("Book", (decimal)12.49, false, 1);
            Product product2 = new Normal("Music CD", (decimal)14.99, false, 2);
            Dictionary<Product, uint> products = new Dictionary<Product, uint> 
            { 
                { product1, 1 },
                { product2, 2 }
            };
            Cart cart = new Cart(products);

            string receipt = cart.CreateReceipt();
            string expectedReceipt = "\nBook: 12.49\nMusic CD: 32.98(2 @ 16.49)\nSales Taxes: 3.00\nTotal: 45.47";
            Assert.AreEqual(expectedReceipt, receipt);
        }
    }
}