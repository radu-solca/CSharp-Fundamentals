using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Exercise1
{
    public class Shop
    {
        private readonly ICollection<Product> products;

        public Shop(ICollection<Product> products)
        {
            this.products = products;
        }

        public void Open()
        {
            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.WriteLine("------------- WELCOME --------------");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();

            bool isShoppingFinished = false;
            while (!isShoppingFinished)
            {
                Console.WriteLine("Available products");
                foreach (var product in products)
                {
                    Console.WriteLine($"{product.Name} ({product.AvailableStock} available)");
                }

                Console.WriteLine();
                Console.WriteLine("What product do you want to buy?");
                string productName = Console.ReadLine();

                Product productToBuy = products.FirstOrDefault(p => p.Name == productName);
                if (productToBuy == null)
                {
                    Console.WriteLine("The product does not exist.");
                    continue;
                }

                Console.WriteLine("How many do you want to buy?");
                int numberToBuy = int.Parse(Console.ReadLine());

                if (numberToBuy > productToBuy.AvailableStock)
                {
                    Console.WriteLine("Not enough items in stock.");
                    continue;
                }

                productToBuy.AvailableStock -= numberToBuy;
                if (productToBuy.AvailableStock == 0)
                {
                    products.Remove(productToBuy);
                }

                Console.WriteLine("Product '" + productName + "' bought!");

                Console.WriteLine();
                Console.WriteLine("Want to buy more? (y/n)");
                string answer = Console.ReadLine();
                if (answer.ToLower() == "n")
                {
                    isShoppingFinished = true;
                    Console.WriteLine("Thank you for shopping here @bestShoppingCenter! Bye!");
                }

                Console.WriteLine();
            }
        }
    }
}
