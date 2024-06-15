abstract class Activity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }

    public Activity(string name, string description, int duration)
    {
        Name = name;
        Description = description;
        Duration = duration;
    }

    public virtual void StartActivity()
    {
        Console.WriteLine($"Starting {Name} activity. {Description}");
        Console.WriteLine($"This activity will last for {Duration} seconds. Prepare to begin...");
        Thread.Sleep(5000);
    }

    public virtual void EndActivity()
    {
        Console.WriteLine("You have done a good job!");
        Console.WriteLine($"You have completed the {Name} activity for {Duration} seconds.");
        Thread.Sleep(3000);
    }
}