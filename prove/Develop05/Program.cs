using System;
using System.Collections.Generic;

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Eternal Quest Program");
        SimpleGoal runMarathon = new SimpleGoal { Name = "Run a Marathon", Points = 1000 };
        runMarathon.RecordEvent();
        Console.WriteLine($"Goal: {runMarathon.Name}, IsComplete: {runMarathon.IsComplete}");
}

public abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }
    public bool IsComplete { get; set; }

    public abstract void RecordEvent();
}

public class SimpleGoal : Goal
{
    public override void RecordEvent()
    {
        IsComplete = true;
        // Add points to user's score
    }
}

public class EternalGoal : Goal
{
    public override void RecordEvent()
    {
        // Add points to user's score
    }
}

public class ChecklistGoal : Goal
{
    public int CompletionCount { get; set; }
    public int TargetCount { get; set; }
    public int BonusPoints { get; set; }

    public override void RecordEvent()
    {
        CompletionCount++;
        if (CompletionCount >= TargetCount)
        {
            IsComplete = true;
            // Add bonus points to user's score
        }
        else
        {
            // Add points to user's score
        }
    }
}

public class User
{
    public int Score { get; set; }
    public List<Goal> Goals { get; set; }

    public void AddGoal(Goal goal)
    {
        Goals.Add(goal);
    }

    public void RecordEvent(Goal goal)
    {
        goal.RecordEvent();
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Score: {Score}");
    }

    public void DisplayGoals()
    {
        foreach (var goal in Goals)
        {
            Console.WriteLine($"{goal.Name}: {goal.IsComplete}");
        }
    }
}