using System;
using System.Collections.Generic;

public class ReflectionActivity : BaseActivity
{
    private static readonly string[] Prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly string[] Questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private List<string> remainingPrompts;
    private List<string> remainingQuestions;

    public ReflectionActivity()
    {
        Name = "Reflection";
        Description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        remainingPrompts = new List<string>(Prompts);
        remainingQuestions = new List<string>(Questions);
    }

    protected override void ExecuteActivity()
    {
        if (remainingPrompts.Count == 0)
        {
            remainingPrompts = new List<string>(Prompts);
        }

        if (remainingQuestions.Count == 0)
        {
            remainingQuestions = new List<string>(Questions);
        }

        Random random = new Random();
        int promptIndex = random.Next(remainingPrompts.Count);
        string prompt = remainingPrompts[promptIndex];
        remainingPrompts.RemoveAt(promptIndex);

        Console.WriteLine(prompt);
        PauseWithAnimation(3);

        int interval = Duration / remainingQuestions.Count;
        foreach (var question in remainingQuestions)
        {
            Console.WriteLine(question);
            PauseWithAnimation(interval);
        }
    }
}