using System;
using System.Threading;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private static readonly Random Random = new Random();
    private static readonly string[] Prompts = new[]
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int duration) : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", duration) { }

    public override void StartActivity()
    {
        base.StartActivity();

        var spinner = new Spinner();
        var startTime = DateTime.Now;

        var spinnerThread = new Thread(() =>
        {
            while ((DateTime.Now - startTime).TotalSeconds < Duration)
            {
                spinner.Turn();
                Thread.Sleep(100); 
            }
        });
        spinnerThread.Start();

        var items = new List<string>();

        Console.WriteLine(Prompts[Random.Next(Prompts.Length)]);
        Console.WriteLine("Get ready to start listing in 5 seconds...");
        Thread.Sleep(5000);
        Console.WriteLine("Start typing now!");

        while ((DateTime.Now - startTime).TotalSeconds < Duration)
        {
            while (!Console.KeyAvailable && (DateTime.Now - startTime).TotalSeconds < Duration)
            {
                Thread.Sleep(100); 
            }

            if (Console.KeyAvailable)
            {
                var item = Console.ReadLine();
                items.Add(item);
            }
        }

        Console.WriteLine($"You listed {items.Count} items.");

        spinnerThread.Join();
    }
}