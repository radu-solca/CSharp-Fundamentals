using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] products = new string[3];
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Product " + (i + 1) + ": ");
                string productName = Console.ReadLine();

                int existingProductIndex = Array.IndexOf(products, productName);
                if (existingProductIndex > -1)
                {
                    Console.WriteLine("Product already exists.");
                    i--;
                }
                else
                {
                    products[i] = productName;
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
                for (int i = 0; i < products.Length; i++)
                {
                    if(!string.IsNullOrEmpty(products[i]))
                    {
                        Console.WriteLine(products[i]);
                    }
                }

                Console.WriteLine();
                Console.WriteLine("What product do you want to buy?");
                string productName = Console.ReadLine();

                int existingProductIndex = Array.IndexOf(products, productName);
                if (existingProductIndex > -1)
                {
                    products[existingProductIndex] = string.Empty;
                    Console.WriteLine("Product '" + productName + "' bought!");
                }
                else
                {
                    Console.WriteLine("The product does not exist.");
                }

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
