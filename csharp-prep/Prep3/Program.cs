using System;

class Program
{
    static void Main()
    {
        bool playAgain = true;

        while (playAgain)
        {
            // Generate a random magic number between 1 and 100
            Random random = new Random();
            int magicNumber = random.Next(1, 101);

            int guess = -1; // Initialize with a value that is not equal to the magic number
            int numberOfGuesses = 0; // Counter for the number of guesses

            // Keep looping until the guess matches the magic number
            while (guess != magicNumber)
            {
                // Ask the user for a guess
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                numberOfGuesses++;

                // Determine if the user needs to guess higher or lower
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {numberOfGuesses} guesses.");
                }
            }

            // Ask the user if they want to play again
            Console.Write("Do you want to play again? (yes/no): ");
            string response = Console.ReadLine().ToLower();

            if (response != "yes")
            {
                playAgain = false;
            }
        }
    }
}
