using SalesTax.Cart;
using SalesTax.Products;
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        var products = StartDialogue();
        Cart cart = new Cart(products);
        string receipt = cart.CreateReceipt();
        cart.WriteReceipt(receipt);
    }

    /*
     * This method displays dialogue and captures user input to create a list of products
     */
    static Dictionary<Product, uint> StartDialogue()
    {
        var products = new Dictionary<Product, uint>();
        while (true)
        {
            Console.WriteLine("Welcome to your Shopping Cart");
            Console.WriteLine("Please enter the name of your Product. (ex. box of chocolates)");
            string pName = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Please enter the price of your Product. (ex. 12.49)");
            decimal pPrice;
            while (!decimal.TryParse(Console.ReadLine(), out pPrice))
            {
                Console.WriteLine("Invalid price entered. Please check the format and try again. (ex. 12.49)");
            }
            Console.Clear();

            Console.WriteLine("Please enter the quantity of your Product. (ex. 1)");
            uint pQuantity;
            while (!uint.TryParse(Console.ReadLine(), out pQuantity))
            {
                Console.WriteLine("Invalid quantity entered. Please check the format and try again. (ex. 1)");
            }
            Console.Clear();

            Console.WriteLine("Is the product an imported item? (Y/N)");
            bool pImported = false;
            while (true)
            {
                string rImport = Console.ReadLine().ToLower();
                if (rImport == "y")
                {
                    pImported = true;
                    break;
                }
                else if (rImport == "n")
                {
                    pImported = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Entry, Please enter Y or N");
                    continue;
                }
            }
            Console.Clear();
            Console.WriteLine("Is the product a book, food, or medical product? (Y/N)");
            while (true)
            {
                string rExempt = Console.ReadLine().ToLower();
                if (rExempt == "y")
                {
                    Exempt newProd = new Exempt(pName, pPrice, pImported, pQuantity);
                    if (products.ContainsKey(newProd))
                    {
                        products[newProd] = products[newProd] + pQuantity;
                    }
                    else
                    {
                        products.Add(newProd, pQuantity);
                    }
                    break;
                }
                else if (rExempt == "n")
                {
                    Normal newProd = new Normal(pName, pPrice, pImported, pQuantity);
                    if (products.ContainsKey(newProd))
                    {
                        products[newProd] = products[newProd] + pQuantity;
                    }
                    else
                    {
                        products.Add(newProd, pQuantity);
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Entry, Please enter Y or N");
                    continue;
                }
            }
            Console.Clear();
            Console.WriteLine("Please hit enter to add another product or type 'done' to get your receipt");
            string input = Console.ReadLine();
            if (input.ToLower() == "done")
                break;
        }
        return products;
    }

}