using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int number;

        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
            if (number != 0)
            {
                numbers.Add(number);
            }
        } while (number != 0);

        // Compute the sum of the numbers in the list
        int sum = numbers.Sum();
        Console.WriteLine($"The sum is: {sum}");

        // Compute the average of the numbers in the list
        double average = numbers.Average();
        Console.WriteLine($"The average is: {average}");

        // Find the maximum number in the list
        int max = numbers.Max();
        Console.WriteLine($"The largest number is: {max}");

        // Find the smallest positive number in the list
        int smallestPositive = numbers.Where(n => n > 0).Min();
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        // Sort the list and display it
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}
