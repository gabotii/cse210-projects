/*
    The program has been extended to include the following features to exceed core requirements:
    For creativity I added a Leveling System: Users gain XP for completing goals and level up, unlocking new bonuses.
    For creativity I added a Large Goals: Goals that require significant effort and can be broken down into milestones.
    For creativity I added a Negative Goals: Goals that deduct points for undesirable behaviors.
    For creativity I added a Bonus Rewards: Users receive bonus points for achieving streaks or completing a series of goals.
    These features add an element of gamification, making the goal tracking system more engaging and motivating.
*/
using System;

class Program
{
    static void Main()
    {
        var manager = new GoalManager();

        while (true)
        {
            Console.WriteLine("1. Add Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Save");
            Console.WriteLine("6. Load");
            Console.WriteLine("7. Display Level");
            Console.WriteLine("8. Exit");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddGoal(manager);
                    break;
                case "2":
                    RecordEvent(manager);
                    break;
                case "3":
                    manager.DisplayGoals();
                    break;
                case "4":
                    manager.DisplayScore();
                    break;
                case "5":
                    SaveManager(manager);
                    break;
                case "6":
                    LoadManager(manager);
                    break;
                case "7":
                    manager.DisplayLevel();
                    break;
                case "8":
                    return;
            }
        }
    }

    static void AddGoal(GoalManager manager)
    {
        Console.WriteLine("Enter goal type (simple, eternal, checklist, large, negative):");
        var type = Console.ReadLine();
        Console.WriteLine("Enter goal name:");
        var name = Console.ReadLine();
        Console.WriteLine("Enter goal points:");
        var points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "simple":
                manager.AddGoal(new SimpleGoal(name, points));
                break;
            case "eternal":
                manager.AddGoal(new EternalGoal(name, points));
                break;
            case "checklist":
                Console.WriteLine("Enter target count:");
                var targetCount = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter bonus points:");
                var bonusPoints = int.Parse(Console.ReadLine());
                manager.AddGoal(new ChecklistGoal(name, points, targetCount, bonusPoints));
                break;
            case "large":
                Console.WriteLine("Enter target count:");
                targetCount = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter milestone points:");
                var milestonePoints = int.Parse(Console.ReadLine());
                manager.AddGoal(new LargeGoal(name, points, targetCount, milestonePoints));
                break;
            case "negative":
                manager.AddGoal(new NegativeGoal(name, points));
                break;
        }
    }

    static void RecordEvent(GoalManager manager)
    {
        Console.WriteLine("Enter goal name:");
        var name = Console.ReadLine();
        manager.RecordEvent(name);
    }

    static void SaveManager(GoalManager manager)
    {
        Console.WriteLine("Enter filename to save:");
        var filename = Console.ReadLine();
        manager.Save(filename);
    }

    static void LoadManager(GoalManager manager)
    {
        Console.WriteLine("Enter filename to load:");
        var filename = Console.ReadLine();
        manager.Load(filename);
    }
}


