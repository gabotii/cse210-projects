using System;
using System.Collections.Generic;

public class ListingActivity : BaseActivity
{
    private static readonly string[] Prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private List<string> remainingPrompts;

    public ListingActivity()
    {
        Name = "Listing";
        Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        remainingPrompts = new List<string>(Prompts);
    }

    protected override void ExecuteActivity()
    {
        if (remainingPrompts.Count == 0)
        {
            remainingPrompts = new List<string>(Prompts);
        }

        Random random = new Random();
        int index = random.Next(remainingPrompts.Count);
        string prompt = remainingPrompts[index];
        remainingPrompts.RemoveAt(index);

        Console.WriteLine(prompt);
        PauseWithAnimation(3);

        Console.WriteLine("Start listing items...");
        PauseWithAnimation(3);

        int itemsCount = 0;
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("Item: ");
            string item = Console.ReadLine();
            itemsCount++;
        }

        Console.WriteLine($"You listed {itemsCount} items.");
    }
}