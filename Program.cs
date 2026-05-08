using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("PRODUCT LIST MANAGER");
        Console.WriteLine("Press any key to exit...");
        Console.WriteLine("Type 'exit' to finish. \n ");

        List<string> products = new List<string>();

        while (true)
        {
            while (true)
        {
            Console.Write("Product: ");
            string input = Console.ReadLine();

            if (input == null)
                continue;

            string normalized = input.Trim().ToLower();

            if (normalized == "exit")
                break;

            products.Add(input.Trim());
        }

        products.Sort();
        Console.WriteLine("\n Sorted Product List:\n");

        foreach (var p in products)
        {
            Console.WriteLine("- " + p);
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
