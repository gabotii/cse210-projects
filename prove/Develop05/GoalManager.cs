using System;
using System.Collections.Generic;
using System.IO;

class GoalManager
{
    private List<Goal> goals;
    private int score;
    private int level;
    private int xp;

    public GoalManager()
    {
        goals = new List<Goal>();
        score = 0;
        level = 1;
        xp = 0;
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordEvent(string goalName)
    {
        foreach (var goal in goals)
        {
            if (goal.Name == goalName)
            {
                int points = goal.RecordEvent();
                score += points;
                xp += points;
                CheckLevelUp();
                return;
            }
        }
    }

    private void CheckLevelUp()
    {
        int requiredXP = level * 100;
        if (xp >= requiredXP)
        {
            level++;
            xp -= requiredXP;
            Console.WriteLine($"Congratulations! You've leveled up to level {level}.");
        }
    }

    public void DisplayGoals()
    {
        foreach (var goal in goals)
        {
            Console.WriteLine($"{goal.GetStatus()} {goal.Name}");
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Score: {score}");
    }

    public void DisplayLevel()
    {
        Console.WriteLine($"Level: {level}, XP: {xp}/{level * 100}");
    }

    public void Save(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(score);
            writer.WriteLine(level);
            writer.WriteLine(xp);
            foreach (var goal in goals)
            {
                writer.WriteLine($"{goal.GetType().Name};{goal.Name};{goal.Points};{(goal is ChecklistGoal checklistGoal ? $"{checklistGoal.CurrentCount};{checklistGoal.TargetCount};{checklistGoal.BonusPoints}" : goal is LargeGoal largeGoal ? $"{largeGoal.CurrentCount};{largeGoal.TargetCount};{largeGoal.MilestonePoints}" : "")}");
            }
        }
    }

    public void Load(string filename)
    {
        using (StreamReader reader = new StreamReader(filename))
        {
            score = int.Parse(reader.ReadLine());
            level = int.Parse(reader.ReadLine());
            xp = int.Parse(reader.ReadLine());
            goals.Clear();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(';');
                var type = parts[0];
                var name = parts[1];
                var points = int.Parse(parts[2]);

                switch (type)
                {
                    case nameof(SimpleGoal):
                        goals.Add(new SimpleGoal(name, points));
                        break;
                    case nameof(EternalGoal):
                        goals.Add(new EternalGoal(name, points));
                        break;
                    case nameof(ChecklistGoal):
                        var currentCount = int.Parse(parts[3]);
                        var targetCount = int.Parse(parts[4]);
                        var bonusPoints = int.Parse(parts[5]);
                        var checklistGoal = new ChecklistGoal(name, points, targetCount, bonusPoints);
                        for (int i = 0; i < currentCount; i++)
                        {
                            checklistGoal.RecordEvent();
                        }
                        goals.Add(checklistGoal);
                        break;
                    case nameof(LargeGoal):
                        currentCount = int.Parse(parts[3]);
                        targetCount = int.Parse(parts[4]);
                        var milestonePoints = int.Parse(parts[5]);
                        var largeGoal = new LargeGoal(name, points, targetCount, milestonePoints);
                        for (int i = 0; i < currentCount; i++)
                        {
                            largeGoal.RecordEvent();
                        }
                        goals.Add(largeGoal);
                        break;
                    case nameof(NegativeGoal):
                        goals.Add(new NegativeGoal(name, points));
                        break;
                }
            }
        }
    }
}
