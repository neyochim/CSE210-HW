using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Mindfulness App! Please choose an activity:");
        Console.WriteLine("1. Breathing");
        Console.WriteLine("2. Reflection");
        Console.WriteLine("3. Listing");

        int choice = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Please enter the duration for the activity in seconds:");
        int duration = Convert.ToInt32(Console.ReadLine());

        Activity activity = choice switch
        {
            1 => new BreathingActivity(duration),
            2 => new ReflectionActivity(duration),
            3 => new ListingActivity(duration),
            _ => throw new Exception("Invalid choice"),
        };

        activity.StartActivity();
        activity.EndActivity();
    }
}