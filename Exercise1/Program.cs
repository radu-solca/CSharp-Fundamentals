using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise1
{
    public class Program
    {
        static void Main(string[] args)
        {
            ICollection<Product> products = new List<Product>();
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Product {i + 1}: ");
                string productName = Console.ReadLine();

                Console.Write($"Available Stock for {productName}: ");
                int availableStock = int.Parse(Console.ReadLine());

                Product existingProduct = products.FirstOrDefault(p => p.Name == productName);
                if (existingProduct != null)
                {
                    Console.WriteLine("Product already exists.");
                    i--;
                }
                else
                {
                    products.Add(new Product
                    {
                        Name = productName,
                        AvailableStock = availableStock
                    });;
                    Console.WriteLine("Product '" + productName + "' added.");
                }
            }

            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.WriteLine("------------- WELCOME --------------");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();

            bool isShoppingFinished = false;
            while(!isShoppingFinished)
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
                if(answer.ToLower() == "n")
                {
                    isShoppingFinished = true;
                    Console.WriteLine("Thank you for shopping here @bestShoppingCenter! Bye!");
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
