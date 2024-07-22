using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Activity running = new Running("2024-07-18", 30, 3.0);
        Activity cycling = new Cycling("2024-07-18", 45, 20.0);
        Activity swimming = new Swimming("2024-07-18", 60, 40);

        List<Activity> activities = new List<Activity> { running, cycling, swimming };

        foreach (var activity in activities)
        { 
            Console.WriteLine(activity.GetSummary());
        }
    }
}