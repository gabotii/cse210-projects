// - For creativity I Added functionality to save and load journal entries as a CSV file, handling commas and quotes properly.
// - For creativity I Implemented a notification system to remind users to write their journal entries at a set time.
// - Enhanced user interface with additional prompts and error handling for a better user experience.
using System;

namespace JournalApp
{
    class Program
    {
        static void Main()
        {
            Journal journal = new Journal();
            bool running = true;

            while (running)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to a file");
                Console.WriteLine("4. Load the journal from a file");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter your journal entry: ");
                        string content = Console.ReadLine();
                        journal.AddEntry(content);
                        break;
                    case "2":
                        journal.DisplayEntries();
                        break;
                    case "3":
                        Console.Write("Enter the filename to save to: ");
                        string saveFilename = Console.ReadLine();
                        journal.SaveToFile(saveFilename);
                        Console.WriteLine("Journal saved.");
                        break;
                    case "4":
                        Console.Write("Enter the filename to load from: ");
                        string loadFilename = Console.ReadLine();
                        journal.LoadFromFile(loadFilename);
                        Console.WriteLine("Journal loaded.");
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
