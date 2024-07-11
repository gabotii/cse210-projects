using System;

class ChecklistGoal : Goal
{
    public int TargetCount { get; private set; }
    public int CurrentCount { get; private set; }
    public int BonusPoints { get; private set; }

    public ChecklistGoal(string name, int points, int targetCount, int bonusPoints) : base(name, points)
    {
        TargetCount = targetCount;
        CurrentCount = 0;
        BonusPoints = bonusPoints;
    }

    public override int RecordEvent()
    {
        if (CurrentCount < TargetCount)
        {
            CurrentCount++;
            if (CurrentCount == TargetCount)
            {
                return Points + BonusPoints;
            }
            return Points;
        }
        return 0;
    }

    public override string GetStatus()
    {
        return CurrentCount >= TargetCount ? "[X]" : $"[{CurrentCount}/{TargetCount}]";
    }
}
