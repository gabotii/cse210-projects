using System;

public class BreathingActivity : BaseActivity
{
    public BreathingActivity()
    {
        Name = "Breathing";
        Description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    protected override void ExecuteActivity()
    {
        int interval = Duration / 2;
        for (int i = 0; i < Duration; i += interval)
        {
            Console.WriteLine("Breathe in...");
            PauseWithEnhancedAnimation(interval, true);
            Console.WriteLine("Breathe out...");
            PauseWithEnhancedAnimation(interval, false);
        }
    }

    private void PauseWithEnhancedAnimation(int seconds, bool growing)
    {
        for (int i = 0; i < seconds; i++)
        {
            if (growing)
            {
                Console.Write(new string(' ', i) + "|");
            }
            else
            {
                Console.Write(new string(' ', seconds - i) + "|");
            }
            Thread.Sleep(100);
            Console.Write("\r");
        }
        Console.Write(new string(' ', seconds) + "\r");
    }
}