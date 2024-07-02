// For creativity I ensured unique prompt selection in each session for ListingActivity and ReflectionActivity.
// For creativity I added functionality to save and load the activity log to/from a file.
// For creativity I enhanced the breathing animation to be more meaningful.
using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            string choice = Console.ReadLine();

            BaseActivity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please choose again.");
                    continue;
            }

            activity.StartActivity();
        }
    }
}
