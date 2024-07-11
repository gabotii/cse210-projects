using System;

abstract class Goal
{
    public string Name { get; private set; }
    public int Points { get; protected set; }

    protected Goal(string name, int points)
    {
        Name = name;
        Points = points;
    }

    public abstract int RecordEvent();
    public abstract string GetStatus();
}
