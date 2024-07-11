using System;

class LargeGoal : Goal
{
    public int TargetCount { get; private set; }
    public int CurrentCount { get; private set; }
    public int MilestonePoints { get; private set; }

    public LargeGoal(string name, int points, int targetCount, int milestonePoints) : base(name, points)
    {
        TargetCount = targetCount;
        CurrentCount = 0;
        MilestonePoints = milestonePoints;
    }

    public override int RecordEvent()
    {
        if (CurrentCount < TargetCount)
        {
            CurrentCount++;
            return Points + (CurrentCount % (TargetCount / 10) == 0 ? MilestonePoints : 0);
        }
        return 0;
    }

    public override string GetStatus()
    {
        return CurrentCount >= TargetCount ? "[X]" : $"[{CurrentCount}/{TargetCount}]";
    }
}
