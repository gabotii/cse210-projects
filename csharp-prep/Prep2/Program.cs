using System;

class Program
{
    static void Main()
    {
        // Prompt the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        int percentage;

        // Ensure the input is a valid integer
        while (!int.TryParse(input, out percentage) || percentage < 0 || percentage > 100)
        {
            Console.Write("Invalid input. Please enter a valid grade percentage (0-100): ");
            input = Console.ReadLine();
        }

        // Initialize variables to hold the letter grade and sign
        string letter;
        string sign = "";

        // Determine the letter grade using if-elif-else statements
        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine the sign for the grade
        if (letter != "A" && letter != "F") // No A+ and no F+ or F-
        {
            int lastDigit = percentage % 10;
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        else if (letter == "A")
        {
            int lastDigit = percentage % 10;
            if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        // Print the letter grade with sign
        Console.WriteLine($"Your letter grade is: {letter}{sign}");

        // Determine if the user passed or failed and display an appropriate message
        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations, you passed the course!");
        }
        else
        {
            Console.WriteLine("Unfortunately, you did not pass the course. Better luck next time!");
        }
    }
}
