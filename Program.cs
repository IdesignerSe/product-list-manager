using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("PRODUCT LIST MANAGER - LEVEL 3\n");
        Console.WriteLine("Enter product names.");
        Console.WriteLine("Type 'exit' to finish.\n");

        List<string> validProducts = new List<string>();

        while (true)
        {
            Console.Write("Product: ");
            string? input = Console.ReadLine();

            if (input == null)
                continue;

            string normalized = input.Trim();

            // Exit handling (case-insensitive)
            if (normalized.Equals("exit", StringComparison.OrdinalIgnoreCase))
                break;

            // Empty input
            if (string.IsNullOrWhiteSpace(normalized))
            {
                Console.WriteLine("ERROR: Input cannot be empty.");
                continue;
            }

            // Validate
            string errorMessage;
            if (IsValidProduct(normalized, out errorMessage))
            {
                validProducts.Add(normalized);
            }
            else
            {
                Console.WriteLine("ERROR: " + errorMessage);
            }
        }

        validProducts.Sort();

        Console.WriteLine("\nSorted valid products:\n");

        foreach (var p in validProducts)
        {
            Console.WriteLine("- " + p);
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadLine();    }

    static bool IsValidProduct(string product, out string errorMessage)
    {
        errorMessage = string.Empty;

        // Must contain a dash
        int dashIndex = product.IndexOf('-');
        if (dashIndex == -1)
        {
            errorMessage = "The left side must contain letters only.";
            return false;
        }

        string left = product.Substring(0, dashIndex).Trim();
        string right = product.Substring(dashIndex + 1).Trim();

        // LEFT SIDE VALIDATION
        if (string.IsNullOrWhiteSpace(left))
        {
            errorMessage = "The left side must contain letters only.";
            return false;
        }

        foreach (char c in left)
        {
            if (!char.IsLetter(c))
            {
                errorMessage = "The left side must contain letters only.";
                return false;
            }
        }

        // RIGHT SIDE VALIDATION
        if (string.IsNullOrWhiteSpace(right))
        {
            errorMessage = "The right side must contain numbers only.";
            return false;
        }

        int number;
        if (!int.TryParse(right, out number))
        {
            errorMessage = "The right side must contain numbers only.";
            return false;
        }

        if (number < 200 || number > 500)
        {
            errorMessage = "The numeric part must be between 200 and 500.";
            return false;
        }

        return true;
    }
}
