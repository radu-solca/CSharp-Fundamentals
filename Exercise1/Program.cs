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
                    continue;
                }
               
                products.Add(new Product
                {
                    Name = productName,
                    AvailableStock = availableStock
                });

                Console.WriteLine("Product '" + productName + "' added.");
            }

            Shop shop = new Shop(products);
            shop.Open();

            Console.ReadLine();
        }
    }
}
